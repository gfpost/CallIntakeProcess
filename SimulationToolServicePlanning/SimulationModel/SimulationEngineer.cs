using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Simulation.Model
{
    public class SimulationEngineer : SimulationObject
    {
        public int ShiftDurationInMinutes { get; private set; }
        public List<string> Skills { get; private set; } = new List<string>();
        public List<string> Regions { get; private set; } = new List<string>();
        public SimulationShift[] ShiftsPerDayIndex;

        public long MaxTravelSecondsBetweenTasks = long.MaxValue;

        internal SimulationEngineer(int id, int shiftDurationInMinutes) 
        { 
            Id = id;
            ShiftDurationInMinutes = shiftDurationInMinutes;
        }

        public SimulationEngineer(string line)
        {
            var array = line.Split(';');
            Debug.Assert(array.Length >= 5);
            Id = Convert.ToInt32(array[0]);
            ShiftDurationInMinutes = Convert.ToInt32(array[1]);
            SetCoordinates(array[2]);

            var skills = array[3].Split(',');
            foreach (var skill in skills)
                Skills.Add(skill.Trim());

            var regions = array[4].Split(',');
            foreach (var region in regions)
                Regions.Add(region.Trim());

            // Convert the minutes to seconds:
            if (array.Length > 5 && long.TryParse(array[5], out long result))
                MaxTravelSecondsBetweenTasks = 60 * result;
        }

        public bool CanDoTask(SimulationTask task)
        {
            if (task.Skill != null && !Skills.Contains(task.Skill))
                return false;

            if (task.Region != null && !Regions.Contains(task.Region))
                return false;

            // All checks passed:
            return true;
        }

        public string ToExportString()
        {
            var sb = new StringBuilder();
            foreach (var skill in Skills)
                sb.Append(skill + ",");

            string skillstr = sb.ToString();
            skillstr = skillstr.Length > 0 ? skillstr.Substring(0, skillstr.Length - 1) : "";

            sb.Clear();
            foreach (var region in Regions)
                sb.Append(region + ",");

            string regionstr = sb.ToString();
            regionstr = regionstr.Length > 0 ? regionstr.Substring(0, regionstr.Length - 1) : "";

            return $"{Id};{ShiftDurationInMinutes};{Coordinates[0]},{Coordinates[1]};{skillstr};{regionstr}";
        }
    }
}
