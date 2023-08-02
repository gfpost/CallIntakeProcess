using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Simulation.Model
{
    public class ParameterRange
    {
        public int Minimum;
        public int Maximum;
        public int Average;

        public ParameterRange(int min, int avg, int max)
        {
            Minimum = min;
            Average = avg;
            Maximum = max;
            Distribution = DistributionUtilities.GetDistribution(min, avg, max);
        }

        public double[] Distribution;
        public int NextValue(Random rand)
        {
            double val = rand.NextDouble();
            double sum = Distribution[0] + 0.00000001;
            int indx = 0;
            while (sum <= val)
            {
                ++indx;
                sum += Distribution[indx];
            }
            Debug.Assert(indx < Distribution.Length);
            return Minimum + indx;
        }
    }

    public class SimulationConfiguration
    {
        // Simulation:
        public int NumberOfDays;
        public int BlockTimeDuration;
        public int SpeedKmH;
        public int RandomPercentage;

        // Tasks:
        public ParameterRange NumberOfTasks;
        public ParameterRange TaskDurationInMinutes;
        public ParameterRange SLaDeadline;

        // Skills:
        public double[] SkillChances;
        public int NumberOfSkills;

        // Employees:
        public int ShiftDuration;
        public List<string>[] SkillIndicesPerEmployee;
        public int NumberOfEmployees { get { return SkillIndicesPerEmployee.Length; } }

        // Area and regions:
        public int AreaWidth;
        public int AreaHeight;
        public int NumberOfRegionsInWidth;
        public int NumberOfRegionsInHeight;
        public double VehicleSpeedKmH;

        private readonly double DurationStepInSeconds = 300.0;

        public string NextSkill(Random rand)
        {
            double val = rand.NextDouble();
            double sum = SkillChances[0] + 0.00000001;
            int indx = 0;
            while (sum <= val)
            {
                ++indx;
                sum += SkillChances[indx];
            }
            Debug.Assert(indx < SkillChances.Length);
            return $"s{indx}";
        }

        private SimulationTask CreateTask(int dayIndex, Random rand)
        {
            var result = new SimulationTask
            {
                IntakeDayIndex = dayIndex,
                Deadline = dayIndex + SLaDeadline.NextValue(rand),
                DurationInSeconds = (long)Math.Max(DurationStepInSeconds, DurationStepInSeconds * Math.Round(TaskDurationInMinutes.NextValue(rand) * 60.0 / DurationStepInSeconds, 0)),
                Skill = NextSkill(rand),
                Coordinates = new int[2]
            };

            result.Coordinates[0] = rand.Next(AreaWidth);
            result.Coordinates[1] = rand.Next(AreaHeight);
            result.Region = GetRegion(result.Coordinates);

            return result;
        }

        private string GetRegion(int[] coords)
        {
            int regionWidth = AreaWidth / NumberOfRegionsInWidth;
            int regionX = coords[0] / regionWidth;
            Debug.Assert(regionX < NumberOfRegionsInWidth);

            int regionHeight = AreaHeight / NumberOfRegionsInHeight;
            int regionY = coords[1] / regionHeight;
            Debug.Assert(regionY < NumberOfRegionsInHeight);

            return $"r{regionX}-{regionY}";
        }

        private List<string> GetRegionAndAdjacents(int[] coords)
        {
            var result = new List<string>();
            result.Add(GetRegion(coords));

            // Adjacent regions:
            /*
            int regionWidth = AreaWidth / NumberOfRegionsInWidth;
            int regionHeight = AreaHeight / NumberOfRegionsInHeight;

            if (coords[0] >= regionWidth)
            {
                int[] curcoords = new int[] { coords[0] - regionWidth, coords[1] };
                result.Add(GetRegion(curcoords));
            }

            if (coords[1] >= regionHeight)
            {
                int[] curcoords = new int[] { coords[0], coords[1] - regionHeight };
                result.Add(GetRegion(curcoords));
            }

            if (coords[0] + regionWidth < AreaWidth)
            {
                int[] curcoords = new int[] { coords[0] + regionWidth, coords[1] };
                result.Add(GetRegion(curcoords));
            }

            if (coords[1] + regionHeight < AreaHeight)
            {
                int[] curcoords = new int[] { coords[0], coords[1] + regionHeight };
                result.Add(GetRegion(curcoords));
            }
            */

            return result;
        }

        private SimulationEngineer CreateEmployee(int idxEmployee, Random rand)
        {
            var result = new SimulationEngineer(idxEmployee, ShiftDuration);

            foreach (string skill in SkillIndicesPerEmployee[idxEmployee])
                result.Skills.Add(skill);

            result.Coordinates = new int[2];
            result.Coordinates[0] = rand.Next(AreaWidth);
            result.Coordinates[1] = rand.Next(AreaHeight);
            result.Regions.AddRange(GetRegionAndAdjacents(result.Coordinates));

            return result;
        }

        public void CreateData(string directory, int version, Random rand)
        {
            var sb = new StringBuilder();

            // Tasks:
            int lastTaskID = 0;
            for (int idxDay = 0; idxDay < NumberOfDays; ++idxDay)
            {
                int nofTasks = NumberOfTasks.NextValue(rand);
                for (int idxTask = 0; idxTask < nofTasks; ++idxTask)
                {
                    var task = CreateTask(idxDay, rand);
                    ++lastTaskID;
                    task.Id = lastTaskID;
                    sb.AppendLine(task.ToExportString());
                }
            }

            string tasksfilename = $"{directory}\\Tasks_v{version}.txt";
            File.WriteAllText(tasksfilename, sb.ToString());

            // Employees:
            sb.Clear();
            for (int idxEmployee = 0; idxEmployee < NumberOfEmployees; ++idxEmployee)
            {
                var employee = CreateEmployee(idxEmployee, rand);
                sb.AppendLine(employee.ToExportString());
            }

            string employeesfilename = $"{directory}\\Employees_v{version}.txt";
            File.WriteAllText(employeesfilename, sb.ToString());

            // Simulation:
            sb.Clear();

            sb.AppendLine($"{NumberOfDays};{BlockTimeDuration};{SpeedKmH};{RandomPercentage}");
            string configurationfilename = $"{directory}\\Configuration_v{version}.txt";
            File.WriteAllText(configurationfilename, sb.ToString());
        }
    }
}
