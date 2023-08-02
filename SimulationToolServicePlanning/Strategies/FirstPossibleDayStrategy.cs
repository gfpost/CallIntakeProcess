using System;
using Simulation.Model;

namespace Simulator
{
    public class FirstPossibleDayStrategy : ParametrizedStrategy
    {
        public override Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            travel = long.MaxValue;
            if (!shift.CanDoTask(task, idxFirstDayOfPlanning, FirstDayForMaximumTravelTimeCheck))
                return null;

            long bestextratraveltime = long.MaxValue;
            for (int i = 0; i <= shift.Tasks.Count; ++i)
            {
                if (shift.CanInsertTaskAtIndex(task, i, blocktime, out long extratraveltime) && extratraveltime < bestextratraveltime)
                    bestextratraveltime = extratraveltime;
            }

            if (bestextratraveltime == long.MaxValue)
                return null;

            long adjustedtraveltime = GetAdjustedTravelTimeForEmptyShift(shift, task, bestextratraveltime);
            return new Objective(shift.DayIndex, adjustedtraveltime);
        }

        public override string ToString()
        {
            return "First possible day";
        }
    }
}
