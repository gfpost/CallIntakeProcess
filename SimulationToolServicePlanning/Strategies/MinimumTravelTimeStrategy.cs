using System;
using System.Collections.Generic;
using Simulation.Model;

namespace Simulator
{
    public class MinimumTravelTimeStrategy : ParametrizedStrategy
    {
        public MinimumTravelTimeStrategy()
        {
            TaskSelection = TaskSelectionMethod.FirstInList;
            ReductionPerDay = null;
            ReductionPercentageForEmptyShift = new List<int> { 50 };
            PenaltyForDaysLate = new List<int> { 1 };
        }

        public override Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            travel = long.MaxValue;
            if (!shift.CanDoTask(task, idxFirstDayOfPlanning, FirstDayForMaximumTravelTimeCheck))
                return null;

            long bestextratraveltime = long.MaxValue;
            for (int i = 0; i <= shift.Tasks.Count; ++i)
            {
                if (shift.CanInsertTaskAtIndex(task, i, blocktime, out long extratraveltime) && extratraveltime < bestextratraveltime)
                    bestextratraveltime = Math.Min(bestextratraveltime, extratraveltime);
            }

            if (bestextratraveltime == long.MaxValue)
                return null;
            
            // Calculate the objective:
            int latenessPenalty = GetPenaltyForLateness(shift.DayIndex - task.Deadline);
            long adjustedtraveltime = GetAdjustedTravelTimeForEmptyShift(shift, task, bestextratraveltime);
            adjustedtraveltime = GetAdjustedTravelTimeForDay(shift, idxFirstDayOfPlanning, adjustedtraveltime);
            return new Objective(latenessPenalty, adjustedtraveltime, shift.DayIndex);
        }

        public override string ToString()
        {
            return "Minimum detour duration";
        }
    }
}
