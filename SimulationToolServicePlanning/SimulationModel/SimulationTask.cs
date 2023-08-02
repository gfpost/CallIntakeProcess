using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Simulation.Model
{
	    public class SimulationTaskList: List<SimulationTask>
    {
        public long GetTotalDuration()
        {
            long result = 0;
            foreach (var task in this)
                result += task.DurationInSeconds;

            return result;
        }
    }
	
    public class SimulationTask : SimulationObject
    {
        public long DurationInSeconds { get; internal set; }
        public int IntakeDayIndex { get; internal set; }
        public int Deadline { get; internal set; }
        public string Skill { get; internal set; }
        public string Region { get; internal set; }

        public SimulationBlockTime BlockTime { get; set; }

        public bool RandomAssignment { get; set; }

        public string CreateRegion()
        {
            if (!string.IsNullOrEmpty(Region))
                return Region;

            int x = Coordinates[0] - 1;
            int compy = 99 - Coordinates[1];
            int result = 1 + 3 * (compy / 33) + (x / 33);
            Debug.Assert(result >= 0 && result <= 9);

            return result.ToString();
        }

        internal SimulationTask() { }

        public SimulationTask(string line)
        {
            var array = line.Split(';');
            Debug.Assert(array.Length >= 5);
            Id = Convert.ToInt32(array[0]);

            // The day the task became available (planning on the next day is possible, not on the same day) 
            IntakeDayIndex = Convert.ToInt32(array[1]);

            // Deadline expresses the last day (inclusive) of allowed planning:
            Deadline = Convert.ToInt32(array[2]);

            // Duration in minutes:
            DurationInSeconds = 60 * Convert.ToInt32(array[3]);

            // x and y coordinate:
            SetCoordinates(array[4]);

            Skill  = array.Length >= 6 && !string.IsNullOrEmpty(array[5]) ? array[5].Trim() : null;
            Region = array.Length >= 7 && !string.IsNullOrEmpty(array[6]) ? array[6].Trim() : null;
        }

        public string ToExportString()
        {
            return $"{Id};{IntakeDayIndex};{Deadline};{DurationInSeconds/60};{Coordinates[0]},{Coordinates[1]};{Skill};{Region}";
        }
    }
}
