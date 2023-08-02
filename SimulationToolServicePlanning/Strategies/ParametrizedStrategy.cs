using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Simulation.Model;

namespace Simulator
{
    public enum TaskSelectionMethod { FirstInList, ClosestToEmployee };

    public class ParametrizedStrategy : ISimulationStrategy
    {
        public TaskSelectionMethod TaskSelection { get; set; }
        public List<int> ReductionPerDay { get; set; }

        public List<int> ReductionNonEmptyShiftsPerDay { get; set; }

        public List<int> ReductionPercentageForEmptyShift { get; set; }
        public List<int> PenaltyForDaysLate { get; set; }
        public List<int> OptimizationDays { get; set; }

        private readonly int ExtraDaysForDeadlinePercentage = 51;
        public int OptimizationTimePerDayMSec { get; set; }
        public int FirstDayForMaximumTravelTimeCheck { get; set; } = int.MaxValue;
        public int MaxMinutesBetweenTasks { get; set; } = int.MaxValue;

        public bool AddNotPlannedToWaitingList { get; set; }

        public static string ListToString(List<int> list)
        {
            if (list == null)
                return null;

            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; ++i)
                if (i < list.Count - 1)
                    sb.Append($"{list[i]},");
                else
                    sb.Append($"{list[i]}");

            return sb.ToString();
        }

        public string GetSummary()
        {
            return $"selection {TaskSelection}; day reductions {ListToString(ReductionPerDay)}; shift reductions {ListToString(ReductionPercentageForEmptyShift)}; late penalties {ListToString(PenaltyForDaysLate)}; optimization days {ListToString(OptimizationDays)}; optimization time {OptimizationTimePerDayMSec} msec; first day for max check: {FirstDayForMaximumTravelTimeCheck}; max minutes between tasks: {MaxMinutesBetweenTasks}";
        }

        protected int GetPenaltyForLateness(int numberOfDaysLate)
        {           
            if (numberOfDaysLate <= 0)
                return 0;

            if (PenaltyForDaysLate == null)
                return numberOfDaysLate;

            int calculationNumber = numberOfDaysLate > PenaltyForDaysLate.Count ? PenaltyForDaysLate.Count - 1 : numberOfDaysLate - 1;
            return PenaltyForDaysLate[calculationNumber];
        }

        protected long GetAdjustedTravelTimeForEmptyShift(SimulationShift shift, SimulationTask task, long detourTravelTime)
        {
            if (ReductionPercentageForEmptyShift == null || shift.Tasks.Count > 0)
                return detourTravelTime;

            var traveltime = TravelTimes.TravelTimeBetween(shift.Engineer, task);

            // If the duration plus travel time is large, the flexibility is not so high:
            long usedDuration = task.DurationInSeconds + traveltime;
            int percentageIndex = (int) (usedDuration * 10 / shift.DurationInSeconds);
            if (percentageIndex >= ReductionPercentageForEmptyShift.Count)
                return detourTravelTime;

            int percentage = ReductionPercentageForEmptyShift[percentageIndex];
            return detourTravelTime - percentage * traveltime / 100;
        }

        protected long GetAdjustedTravelTimeForDay(SimulationShift shift, int idxFirstDayOfPlanning, long originalTravelTime)
        {
            int dayIndex = shift.DayIndex - idxFirstDayOfPlanning;
            Debug.Assert(dayIndex >= 0);
            int amount = 0;
            if (ReductionPerDay != null && dayIndex < ReductionPerDay.Count)
                amount = ReductionPerDay[dayIndex];

            if (ReductionNonEmptyShiftsPerDay != null && shift.Tasks.Count > 0 && dayIndex < ReductionNonEmptyShiftsPerDay.Count)
                amount += ReductionNonEmptyShiftsPerDay[dayIndex];

            return originalTravelTime - amount;
        }

        public void CopyParamsFrom(ParametrizedStrategy paramStrategy)
        {
            TaskSelection = paramStrategy.TaskSelection;

            ReductionPerDay = null;
            if (paramStrategy.ReductionPerDay != null)
            {
                ReductionPerDay = new List<int>();
                ReductionPerDay.AddRange(paramStrategy.ReductionPerDay);
            }

            ReductionNonEmptyShiftsPerDay = null;
            if (paramStrategy.ReductionNonEmptyShiftsPerDay != null)
            {
                ReductionNonEmptyShiftsPerDay = new List<int>();
                ReductionNonEmptyShiftsPerDay.AddRange(paramStrategy.ReductionNonEmptyShiftsPerDay);
            }

            ReductionPercentageForEmptyShift = null;
            if (paramStrategy.ReductionPercentageForEmptyShift != null)
            {
                ReductionPercentageForEmptyShift = new List<int>();
                ReductionPercentageForEmptyShift.AddRange(paramStrategy.ReductionPercentageForEmptyShift);
            }

            PenaltyForDaysLate = null;
            if (paramStrategy.PenaltyForDaysLate != null)
            {
                PenaltyForDaysLate = new List<int>();
                PenaltyForDaysLate.AddRange(paramStrategy.PenaltyForDaysLate);
            }

            OptimizationDays = null;
            if (paramStrategy.OptimizationDays != null)
            {
                OptimizationDays = new List<int>();
                OptimizationDays.AddRange(paramStrategy.OptimizationDays);
            }

            FirstDayForMaximumTravelTimeCheck = paramStrategy.FirstDayForMaximumTravelTimeCheck;
            MaxMinutesBetweenTasks = paramStrategy.MaxMinutesBetweenTasks;            
            OptimizationTimePerDayMSec = paramStrategy.OptimizationTimePerDayMSec;
        }

        public virtual SimulationTask GetTaskToPlan(SimulationModel model, List<SimulationTask> tasks, int dayIndex)
        {
            if (tasks.Count == 0)
                return null;


            if (TaskSelection == TaskSelectionMethod.FirstInList)
                return tasks[0];

            if (TaskSelection == TaskSelectionMethod.ClosestToEmployee)
            {
                SimulationTask result = null;
                long besttraveltime = long.MaxValue;

                foreach (var task in tasks)
                {
                    long traveltime = long.MaxValue;
                    foreach (var employee in model.Employees)
                    {
                        if (employee.CanDoTask(task))
                            traveltime = Math.Min(traveltime, TravelTimes.TravelTimeBetween(employee, task));

                        if (traveltime < besttraveltime)
                        {
                            result = task;
                            besttraveltime = traveltime;
                        }
                    }
                }

                // N.B. It is possible that no employee is found to do the task! In that case null is returned.
                return result;
            }

            // No way to arrive here:
            return null;
        }

        public virtual Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            throw new NotImplementedException();
        }

        public virtual ShiftCost GetBestShiftForTask(SimulationModel model, SimulationTask task, ShiftCostList shiftcosts, Random rand)
        {
            return shiftcosts.GetBest(rand);
        }

        public virtual int GetMaxDaysAfterDeadline(SimulationTask task)
        {
            double numberOfDays = task.Deadline - task.IntakeDayIndex;
            return (int) Math.Round(numberOfDays * ExtraDaysForDeadlinePercentage / 100.0, 0);
        }

        // Insert (by default) at best index:
        public virtual void AddTaskToShift(SimulationTask task, ShiftCost shiftcost)
        {
            task.BlockTime = shiftcost.BlockTime;
            var shift = shiftcost.Shift;

            int bestIndex = -1;
            long besttravel = long.MaxValue;
            for (int i = 0; i <= shift.Tasks.Count; ++i)
            {
                if (shift.CanInsertTaskAtIndex(task, i, shiftcost.BlockTime, out long extratraveltime) && extratraveltime < besttravel)
                {
                    bestIndex = i;
                    besttravel = extratraveltime;
                }
            }

            Debug.Assert(bestIndex > -1);
            shift.AddTaskAtIndex(task, bestIndex);
        }
    }
}
