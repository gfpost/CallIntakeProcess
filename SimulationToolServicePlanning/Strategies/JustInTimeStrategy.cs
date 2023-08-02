using System;
using System.Collections.Generic;
using Simulation.Model;

namespace Simulator
{
    public class JustInTimeStrategy : ParametrizedStrategy
    {
        public JustInTimeStrategy()
        {
            AddNotPlannedToWaitingList = true;
        }

        public override SimulationTask GetTaskToPlan(SimulationModel model, List<SimulationTask> tasks, int dayIndex)
        {
            if (dayIndex + 1 > model.BlockTimesPerDay.Length - 1)
                return null;

            SimulationTask result = null;
            Objective bestCost = new Objective(long.MaxValue);

            foreach (var task in tasks)
            {
                var shiftcosts = new ShiftCostList();
                foreach (var blocktime in model.BlockTimesPerDay[dayIndex + 1])
                {
                    foreach (var shift in model.ShiftsPerDay[dayIndex + 1])
                    {
                        var objective = GetObjectiveForTaskInShift(dayIndex + 1, task, shift, blocktime, out long travel);
                        // If the shift can not do the task (according to the stategy), return null as objective:
                        if (objective != null)
                        {
                            var shiftcost = new ShiftCost(shift, blocktime, travel, objective);
                            shiftcosts.Add(shiftcost);
                        }
                    }
                }

                shiftcosts.Sort();
                if (shiftcosts.Count == 0)
                    continue;

                var cost = shiftcosts[0].Cost;
                if (cost.IsBetterThanOther(bestCost))
                {
                    bestCost = cost;
                    result = task;
                }
            }

            return result;
        }

        public override Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            travel = long.MaxValue;

            // This is characteristic for just in time:
            if (shift.DayIndex > idxFirstDayOfPlanning)
                return null;

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
            int lastIndex = task.Deadline + this.GetMaxDaysAfterDeadline(task);
            return new Objective(lastIndex - shift.DayIndex, adjustedtraveltime);
        }

        public override string ToString()
        {
            return "Just in Time";
        }
    }
}
