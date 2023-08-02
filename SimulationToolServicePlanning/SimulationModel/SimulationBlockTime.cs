using System;

namespace Simulation.Model
{
    public class SimulationBlockTime : IComparable
    {
        public int DayIndex { get; private set; }
        public int IndexOnDay { get; private set; }
        public long StartSecond { get; private set; }
        public long EndSecond { get; private set; }

        // Used for (random) sorting of blocktimes:
        public double TempScore { get; set; }

        public SimulationBlockTime(int dayIndex, int indexOnDay, int startMinute, int endMinute)
        {
            DayIndex = dayIndex;
            IndexOnDay = indexOnDay;
            StartSecond = 60 * startMinute;
            EndSecond = 60 * endMinute;
        }

        public int CompareTo(object obj)
        {
            var other = obj as SimulationBlockTime;
            return TempScore.CompareTo(other.TempScore);
        }
    }
}
