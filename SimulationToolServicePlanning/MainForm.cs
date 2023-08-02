using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Simulation.Model;

namespace Simulator
{
    public partial class MainForm : Form
    {
        private readonly SimulationModel Model;
        private SimulationParameters SimulationParameters = new SimulationParameters { BlockTimeDurationInMinutes = 120, SpeedKmH = 60, RandomPercentage = 0};
        private Simulation Simulation = null;

        public MainForm()
        {
            InitializeComponent();
            Model = new SimulationModel();
        }

        private void SetModelProperties()
        {
            int numberOfTasks = Model.TotalNumberOfTasks;
            tbTasks.Text = $"{numberOfTasks}";
            tbEmployees.Text = $"{Model.Employees.Count}";
        }

        private void SetTasksFromFile(string fileName)
        {
            foreach (var tasklist in Model.TasksPerDay)
                if (tasklist != null)
                    tasklist.Clear();

            string[] taskLines = File.ReadAllLines(fileName);
            foreach (var line in taskLines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("%"))
                    Model.AddTask(line);
            }

            SetModelProperties();
        }

        private void SetConfigurationFromFile(string fileName)
        {
            SimulationParameters = new SimulationParameters();
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("%"))
                {
                    var lineparts = line.Split(';');
                    Debug.Assert(lineparts.Length == 4);

                    SimulationParameters.NumberOfDays = int.Parse(lineparts[0]);
                    tbNumberOfDays.Text = lineparts[0];

                    SimulationParameters.BlockTimeDurationInMinutes = int.Parse(lineparts[1]);
                    tbBlocktimeDuration.Text = lineparts[1];

                    SimulationParameters.SpeedKmH = int.Parse(lineparts[2]);
                    tbSpeed.Text = lineparts[2];

                    SimulationParameters.RandomPercentage = int.Parse(lineparts[3]);
                    tbRandomPercentage.Text = lineparts[3];

                    return;
                }
            }
        }

        private void readTasks_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetTasksFromFile(openFileDialog.FileName);
            }
        }

        private void readEmployees_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Model.Employees.Clear();
                Text = $"Simulation with engineers from file: {Path.GetFileNameWithoutExtension(openFileDialog.FileName)}";

                string[] taskLines = File.ReadAllLines(openFileDialog.FileName);
                foreach (var line in taskLines)
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("%"))
                        Model.AddEmployee(line);
                }

                SetModelProperties();
            }
        }

        private void DisplaySimulationResults()
        {
            if (Simulation == null)
                return;

            int start = Convert.ToInt32(tbStart.Text);
            if (start < 0)
            {
                start = 0;
                tbStart.Text = "0";
            }

            int end = start + Convert.ToInt32(tbDisplayNumberOfDays.Text);
            if (end > Model.NumberOfDays)
            {
                end = Model.NumberOfDays;
                tbDisplayNumberOfDays.Text = $"{end - start}";
            }

            if (end <= start)
            {
                start = end < Model.NumberOfDays ? start : start - 1;
                end = start + 1;
                tbDisplayNumberOfDays.Text = "1";
            }

            int planned = 0;
            foreach (var task in Simulation.ScheduledTasks)
            {
                if (task.IntakeDayIndex >= start && task.IntakeDayIndex < end)
                    ++planned;
            }
            tbPlanned.Text = $"{planned}";

            int unplanned = 0;
            foreach (var task in Simulation.UnscheduledTasks)
            {
                if (task.IntakeDayIndex >= start && task.IntakeDayIndex < end)
                    ++unplanned;
            }
            tbNotPlanned.Text = $"{unplanned}";

            long traveltime = 0;
            for (int idxDay = start; idxDay < end; ++idxDay)
            {
                var shifts = Model.ShiftsPerDay[idxDay];
                foreach (var shift in shifts)
                    traveltime += shift.TotalTravelTimeInSeconds;
            }
            tbTravelTime.Text = $"{traveltime/60}";

            // Collect too lates:
            var tooLates = Model.GetTooLates(start, end);

            tbOneLate.Text = $"{tooLates[1]}";
            tbTwoLate.Text = $"{tooLates[2]}";
            tbThreeLate.Text = $"{tooLates[3]}";
            tbFourLate.Text = $"{tooLates[4]}";
            int fiveOrMore = tooLates.Count > 5 ? tooLates[5] : 0;
            for (int i = 6; i < tooLates.Count; ++i)
                fiveOrMore += tooLates[i];

            tbFiveOrMoreLate.Text = $"{fiveOrMore}";

            // Display shifts:

            if (chart.Visible)
            {
                UpdateChart(start, end);
                return;
            }

            gridShifts.RowCount = Model.Employees.Count + 1;
            gridShifts.ColumnCount = end - start + 1;
            gridShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            for (int idxEmployee = 0; idxEmployee < Model.Employees.Count; ++idxEmployee)
            {
                int row = idxEmployee + 1;
                gridShifts.Rows[row].Cells[0].Value = $"mdw {Model.Employees[idxEmployee].Id}";
            }

            for (int idxDay = start; idxDay < end; ++idxDay)
            {
                int col = idxDay - start + 1;
                gridShifts.Rows[0].Cells[col].Value = $"{idxDay}";
                for (int idxResource = 0; idxResource < Model.Employees.Count; ++idxResource)
                {
                    int row = idxResource + 1;
                    var shift = Model.Employees[idxResource].ShiftsPerDayIndex[idxDay];
                    long taskdur = shift.TotalTaskDurationInSeconds;
                    int percentage = (int)((taskdur + shift.TotalTravelTimeInSeconds) * 100 / shift.DurationInSeconds);

                    gridShifts.Rows[row].Cells[col].Value = $"{shift.Tasks.Count}: {taskdur}+{shift.TotalTravelTimeInSeconds/60} ({percentage}%)";
                }
            }
        }

        private void RunSimulation_Click(object sender, EventArgs e)
        {
            if (Model.TotalNumberOfTasks == 0)
            {
                MessageBox.Show("There are no tasks loaded!");
                return;
            }

            if (Model.Employees.Count == 0)
            {
                MessageBox.Show("There are no engineers loaded!");
                return;
            }

            int numberOfDays = Convert.ToInt32(tbNumberOfDays.Text);
            if (numberOfDays <= 0)
            {
                MessageBox.Show("The number of days is not yet set!");
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnRun.Enabled = false;

            try
            {
                Model.CreateShifts(numberOfDays);
                Model.CreateBlockTimes(numberOfDays, SimulationParameters.BlockTimeDurationInMinutes);
                TravelTimes.SpeedKmH = SimulationParameters.SpeedKmH;

                // Remove previously assigned blocktimes (in case of multiple runs with the same tasks):
                for (int idxDay = 0; idxDay < Model.TasksPerDay.Length; ++idxDay)
                {
                    if (Model.TasksPerDay[idxDay] == null)
                        continue;

                    foreach (var task in Model.TasksPerDay[idxDay])
                    {
                        task.BlockTime = null;
                        task.RandomAssignment = false;
                    }
                }

                var strategy = cbbStrategy.SelectedItem as ParametrizedStrategy;
                Simulation = new Simulation(int.Parse(tbRandomPercentage.Text), strategy);
                Simulation.Run(Model, barProcessingDay);

                Application.DoEvents();

                DisplaySimulationResults();
            }
            finally
            {
                btnRun.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbbStrategy.Items.Add(new JustInTimeStrategy());
            cbbStrategy.Items.Add(new FirstPossibleDayStrategy());
            cbbStrategy.Items.Add(new MinimumTravelToTimeStrategy());
            cbbStrategy.Items.Add(new MinimumTravelToTimeAtEndOfShiftStrategy());
            cbbStrategy.Items.Add(new MinimumTravelTimeStrategy());
            cbbStrategy.SelectedIndex = 0;
        }

        private void graph_Click(object sender, EventArgs e)
        {
            chart.Visible = !chart.Visible;
            miChart.Text = chart.Visible ? "Show grid" : "Show chart";
            DisplaySimulationResults();
        }

        private void UpdateChart(int start, int end)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            chart.Series[2].Points.Clear();

            long totalshiftduration = 0;
            long totaltaskduration = 0;
            long totaltravelduration = 0;
            int totalnumberOfTasks = 0;

            for (int idxDay = start; idxDay < end; ++idxDay)
            {
                long taskduration = 0;
                long travelduration = 0;
                long shiftduration = 0;

                var shifts = Model.ShiftsPerDay[idxDay];
                foreach (var shift in shifts)
                {
                    taskduration += shift.TotalTaskDurationInSeconds;
                    travelduration += shift.TotalTravelTimeInSeconds;
                    shiftduration += shift.DurationInSeconds;
                    totalnumberOfTasks += shift.Tasks.Count;
                }

                totalshiftduration += shiftduration;
                totaltaskduration += taskduration;
                totaltravelduration += travelduration;

                if (shiftduration == 0)
                    shiftduration = 1;

                double taskpercentage = Math.Round(taskduration * 100.0 / shiftduration, 1);
                chart.Series[0].Points.AddXY(idxDay + 1, taskpercentage);

                double travelpercentage = Math.Round((double)travelduration * 100.0 / shiftduration, 1);
                chart.Series[1].Points.AddXY(idxDay + 1, travelpercentage);

                // Rounding is still necessary...
                double unusedpercentage = Math.Round(100.0 - travelpercentage - taskpercentage, 1);
                chart.Series[2].Points.AddXY(idxDay + 1, unusedpercentage - 0.01);
            }

            decimal totaltaskpercentage = (decimal)Math.Round(totaltaskduration * 100.0 / totalshiftduration, 2);
            decimal totaltravelpercentage = (decimal)Math.Round((double)totaltravelduration * 100.0 / totalshiftduration, 2);
            decimal totalunusedpercentage = 100 - totaltravelpercentage - totaltaskpercentage;
            chart.Series[0].Name = $"{StringValue(totaltaskpercentage)}% task duration";
            chart.Series[1].Name = $"{StringValue(totaltravelpercentage)}% travel duration";
            chart.Series[2].Name = $"{StringValue(totalunusedpercentage)}% not used";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int numberOfDays = Math.Min(10, Convert.ToInt32(tbDisplayNumberOfDays.Text));
            int start = Math.Max(0, Convert.ToInt32(tbStart.Text) - numberOfDays);
            tbStart.Text = $"{start}";

            DisplaySimulationResults();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            int numberOfDays = Math.Min(10, Convert.ToInt32(tbDisplayNumberOfDays.Text));
            int start = Convert.ToInt32(tbStart.Text) + numberOfDays;
            tbStart.Text = $"{start}";

            DisplaySimulationResults();
        }

        private void tbDisplayNumberOfDays_Leave(object sender, EventArgs e)
        {
            DisplaySimulationResults();
        }

        private static string StringValue(decimal d)
        {
            int intpart = (int)d;
            decimal fracpart = 100 * (d - intpart);
            return $"{intpart}.{(int)fracpart}";
        }

        private void SavePlanning_Click(object sender, EventArgs e)
        {
            if (Simulation == null)
                return;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            int start = Convert.ToInt32(tbStart.Text);
            int end = start + Convert.ToInt32(tbDisplayNumberOfDays.Text);

            var sb = new StringBuilder();
            for (int idxDay = start; idxDay < end; ++idxDay)
            {
                var shifts = Model.ShiftsPerDay[idxDay];
                foreach (var shift in shifts)
                {
                    var shiftbuilder = new StringBuilder();
                    shiftbuilder.Append($"day: {shift.DayIndex}; engineer: {shift.Engineer.Id}; shift duration: {shift.DurationInSeconds / 60}; travel: {shift.TotalTravelTimeInSeconds / 60}; {shift.Tasks.Count} tasks with total duration: {shift.TotalTaskDurationInSeconds / 60}; ");

                    SimulationObject startpoint = shift.Engineer;
                    shiftbuilder.Append($"start: ({startpoint.Coordinates[0]}, {startpoint.Coordinates[1]}); ");

                    for (int i = 0; i < shift.Tasks.Count; ++i)
                    {
                        var task = shift.Tasks[i];
                        long tt = TravelTimes.TravelTimeBetween(startpoint, task);
                        string randstr = task.RandomAssignment ? " (R)" : "";
                        shiftbuilder.Append($"travel: {tt/60} to task {task.Id}{randstr} (duration {task.DurationInSeconds/60}) at coords ({task.Coordinates[0]}, {task.Coordinates[1]}), block {task.BlockTime.StartSecond / 60} - {task.BlockTime.EndSecond / 60}, start {shift.FirstTaskStarts[i] / 60} - {shift.LastTaskStarts[i] / 60}; ");
                        startpoint = task;
                    }

                    long tthome = TravelTimes.TravelTimeBetween(startpoint, shift.Engineer);
                    shiftbuilder.Append($"travel {tthome/60} to home ({shift.Engineer.Coordinates[0]}, {shift.Engineer.Coordinates[1]})");
                    sb.AppendLine(shiftbuilder.ToString());
                }
            }

            sb.AppendLine($"\nUnscheduled tasks (with day in selected period):");
            foreach (var task in Simulation.UnscheduledTasks)
            {
                if (task.IntakeDayIndex >= start && task.IntakeDayIndex < end)
                    sb.AppendLine($"task {task.Id}; day: {task.IntakeDayIndex}; skill: {task.Skill}; region: {task.Region}; deadline {task.Deadline} at ({task.Coordinates[0]}, {task.Coordinates[1]})");
            }

            using (StreamWriter file = new StreamWriter(saveFileDialog.FileName))
            {
                file.WriteLine(sb.ToString());
            }

        }

        private ParametrizedStrategy SetParametersFromFile(string filename)
        {
            ParametrizedStrategy result = (ParametrizedStrategy)JsonConvert.DeserializeObject(File.ReadAllText(filename), typeof(ParametrizedStrategy));
            foreach (var item in cbbStrategy.Items)
            {
                if (item is ParametrizedStrategy)
                {
                    var strategy = item as ParametrizedStrategy;
                    strategy.CopyParamsFrom(result);
                }
            }

            return result;
        }

        private void ReadStrategieParameters_Click(object sender, EventArgs e)
        {
            var oldFilter = openFileDialog.Filter;
            try
            {
                openFileDialog.Filter = "files|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SetParametersFromFile(openFileDialog.FileName);
                    Text = $"Simulation with parameters from file: {Path.GetFileNameWithoutExtension(openFileDialog.FileName)}";
                }
            }
            finally
            {
                openFileDialog.Filter = oldFilter;
            }

        }

        private void GetTotalDurations(int start, int end, out long shiftduration, out long taskduration, out long travelduration)
        {
            shiftduration = 0;
            taskduration = 0;
            travelduration = 0;

            for (int idxDay = start; idxDay < end; ++idxDay)
            {
                var shifts = Model.ShiftsPerDay[idxDay];
                foreach (var shift in shifts)
                {
                    taskduration += shift.TotalTaskDurationInSeconds;
                    travelduration += shift.TotalTravelTimeInSeconds;
                    shiftduration += shift.DurationInSeconds;
                }
            }
        }

        private string GetSummary()
        {
            int start = Convert.ToInt32(tbStart.Text);
            int end = start + Convert.ToInt32(tbDisplayNumberOfDays.Text);
            var lates = Model.GetTooLates(start, end);
            GetTotalDurations(start, end, out long shiftduration, out long taskduration, out long travelduration);
            long unused = shiftduration - taskduration - travelduration;

            decimal taskpercentage = (decimal)Math.Round(taskduration * 100.0 / shiftduration, 1);
            decimal travelpercentage = (decimal)Math.Round(travelduration * 100.0 / shiftduration, 1);
            decimal unusedpercentage = (decimal)Math.Round(unused * 100.0 / shiftduration, 1);

            lates.RemoveAt(0);
            int toolate = 0;
            foreach (int val in lates)
                toolate += val;

            string toolates = ParametrizedStrategy.ListToString(lates);
            return $"strategy {cbbStrategy.SelectedItem}; planned: {tbPlanned.Text}; unplanned {tbNotPlanned.Text}; late {toolate}; lates per day {toolates}; shift duration {shiftduration/60}; task duration {taskduration/60} ({taskpercentage}%); travel duration {travelduration/60} ({travelpercentage}%); unused duration {unused/60} ({unusedpercentage}%)";
        }

        private void ExecuteStrategies_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var now = DateTime.Now;
                var logfile = folderBrowserDialog.SelectedPath + $"\\{now:yyyy-MM-ddTHHmmss}_SimulationResult.log";
                var sb = new StringBuilder();
                sb.AppendLine($"{Text}; employee count {Model.Employees.Count}; number of days {tbNumberOfDays.Text}; validation start {tbStart.Text}; validation days {tbDisplayNumberOfDays.Text}\n");
                foreach (var tasksfile in Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.txt"))
                {
                    SetTasksFromFile(tasksfile);
                    string filename = Path.GetFileNameWithoutExtension(tasksfile);
                    sb.AppendLine("********* Start loading new tasks  ******\n");
                    sb.AppendLine($"file {filename}; Task count {Model.TotalNumberOfTasks};\n");
                    foreach (var strategyfile in Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.json"))
                    {
                        var strategy = SetParametersFromFile(strategyfile);
                        var strategySummary = $"+++ Parameters file {Path.GetFileNameWithoutExtension(strategyfile)}: {strategy.GetSummary()}";
                        sb.AppendLine(strategySummary);
                        for (int idx = 0; idx < cbbStrategy.Items.Count; ++idx)
                        {
                            if (cbbStrategy.Items[idx] is ParametrizedStrategy)
                            {
                                cbbStrategy.SelectedIndex = idx;
                                Application.DoEvents();
                                RunSimulation_Click(sender, e);
                                string summary = GetSummary();
                                sb.AppendLine(summary);
                                File.WriteAllText(logfile, sb.ToString());
                            }
                        }
                        sb.AppendLine("");
                    }
                }
            }
        }

        private void OpenDataConfiguration_Click(object sender, EventArgs e)
        {
            var configForm = new ConfigurationForm();
            configForm.Show();
        }

        private void ReadConfiguration_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetConfigurationFromFile(openFileDialog.FileName);
            }
        }
    }
}
