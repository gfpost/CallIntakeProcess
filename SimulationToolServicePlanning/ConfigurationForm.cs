using Simulation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Simulator
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dialFolder.ShowDialog() != DialogResult.OK)
                return;

            int version = int.Parse(tbVersion.Text);
            var rand = new Random(version);

            var configuration = new SimulationConfiguration();

            // Simulation:
            configuration.NumberOfDays = int.Parse(tbNofDays.Text);
            configuration.BlockTimeDuration = int.Parse(tbBlocktimeDuration.Text);
            configuration.SpeedKmH = int.Parse(tbSpeed.Text);
            configuration.RandomPercentage = int.Parse(tbRandomAssignment.Text);

            // Tasks:
            configuration.NumberOfTasks = new ParameterRange(int.Parse(tbMinNofTasks.Text), int.Parse(tbAvgNofTasks.Text), int.Parse(tbMaxNofTasks.Text));
            configuration.TaskDurationInMinutes = new ParameterRange(int.Parse(tbMinTaskDuration.Text), int.Parse(tbAvgTaskDuration.Text), int.Parse(tbMaxTaskDuration.Text));
            configuration.SLaDeadline = new ParameterRange(int.Parse(tbMinDeadline.Text), int.Parse(tbAvgDeadline.Text), int.Parse(tbMaxDeadline.Text));

            // Skills:
            configuration.NumberOfSkills = int.Parse(tbNofSkills.Text);

            int avgSkillPercentage = (int)Math.Round(100.0 / configuration.NumberOfSkills, 0);
            int minSkillPercentage = int.Parse(tbMinPercentageSkill.Text);
            Debug.Assert(minSkillPercentage <= 100.00001 / configuration.NumberOfSkills);

            int maxSkillPercentage = int.Parse(tbMaxPercentageSkill.Text);
            Debug.Assert(maxSkillPercentage >= 99.99999 / configuration.NumberOfSkills);

            var skillPercentages = new ParameterRange(minSkillPercentage, avgSkillPercentage, maxSkillPercentage);
            configuration.SkillChances = new double[configuration.NumberOfSkills];
            double totalchance = 0.0;
            for (int i = 0; i < configuration.SkillChances.Length; ++i)
            {
                configuration.SkillChances[i] = skillPercentages.NextValue(rand);
                totalchance += configuration.SkillChances[i];
            }

            // Normalize:
            for (int i = 0; i < configuration.SkillChances.Length; ++i)
                configuration.SkillChances[i] /= totalchance;

            // Employees:
            configuration.ShiftDuration = int.Parse(tbShiftDuration.Text);

            int avgNofSkills = int.Parse(tbAvgNofSkills.Text);
            int maxNofSkills = avgNofSkills + (configuration.NumberOfSkills - avgNofSkills) / 2;
            int minNofSkills = Math.Max(1, avgNofSkills / 2);
            var skills = new ParameterRange(minNofSkills, avgNofSkills, maxNofSkills);

            int numberOfEmployees = int.Parse(tbNofEmployees.Text);
            configuration.SkillIndicesPerEmployee = new List<string>[numberOfEmployees];
            for (int i = 0; i < numberOfEmployees; ++i)
            {
                var empSkills = new List<string>();
                int nofSkills = skills.NextValue(rand);
                Debug.Assert(nofSkills <= configuration.NumberOfSkills);
                if (nofSkills == configuration.NumberOfSkills)
                {
                    for (int j = 0; j < nofSkills; ++j)
                        empSkills.Add($"s{j}");
                }
                else
                {
                    int nofTries = 0;
                    while (empSkills.Count < nofSkills && nofTries < 10 * configuration.NumberOfSkills)
                    {
                        ++nofTries;
                        string skill = configuration.NextSkill(rand);
                        if (!empSkills.Contains(skill))
                            empSkills.Add(skill);
                    }
                }

                configuration.SkillIndicesPerEmployee[i] = empSkills;
            }

            // Area and regions:
            configuration.AreaWidth = int.Parse(tbWidth.Text);
            configuration.AreaHeight = int.Parse(tbHeight.Text);
            configuration.NumberOfRegionsInWidth = int.Parse(tbNofRegionsWidth.Text);
            configuration.NumberOfRegionsInHeight = int.Parse(tbNofRegionsHeight.Text);

            configuration.CreateData(dialFolder.SelectedPath, version, rand);
        }
    }
}
