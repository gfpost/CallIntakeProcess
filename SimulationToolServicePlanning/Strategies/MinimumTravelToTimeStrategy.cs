using System;
using System.Diagnostics;
using Simulation.Model;

namespace Simulator
{
    public class MinimumTravelToTimeStrategy : ParametrizedStrategy
    {
        public override Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            travel = long.MaxValue;
            if (!shift.CanDoTask(task, idxFirstDayOfPlanning, FirstDayForMaximumTravelTimeCheck))
                return null;

            long besttravelto = long.MaxValue;
            for (int i = 0; i <= shift.Tasks.Count; ++i)
            {
                if (shift.CanInsertTaskAtIndex(task, i, blocktime, out long dummy))
                {
                    var startPoint = i == 0 ? (SimulationObject)shift.Engineer : shift.Tasks[i - 1];
                    besttravelto = Math.Min(besttravelto, TravelTimes.TravelTimeBetween(startPoint, task));
                }
            }

            if (besttravelto == long.MaxValue)
                return null;

            // Calculate the objective:
            int latenessPenalty = GetPenaltyForLateness(shift.DayIndex - task.Deadline);
            besttravelto = GetAdjustedTravelTimeForDay(shift, idxFirstDayOfPlanning, besttravelto);
            return new Objective(latenessPenalty, besttravelto, shift.DayIndex, blocktime.IndexOnDay);
        }

        public override void AddTaskToShift(SimulationTask task, ShiftCost shiftcost)
        {
            task.BlockTime = shiftcost.BlockTime;
            var shift = shiftcost.Shift;

            long besttravelto = long.MaxValue;
            int bestIndex = -1;

            for (int i = 0; i <= shift.Tasks.Count; ++i)
            {
                if (shift.CanInsertTaskAtIndex(task, i, shiftcost.BlockTime, out long dummy))
                {
                    var startPoint = i == 0 ? (SimulationObject)shift.Engineer : shift.Tasks[i - 1];
                    long travelto = TravelTimes.TravelTimeBetween(startPoint, task);
                    if (travelto < besttravelto)
                    {
                        bestIndex = i;
                        besttravelto = travelto;
                    }
                }
            }

            Debug.Assert(bestIndex > -1);
            shift.AddTaskAtIndex(task, bestIndex);
        }

        public override string ToString()
        {
            return "Minimum travel time to";
        }
    }
}
