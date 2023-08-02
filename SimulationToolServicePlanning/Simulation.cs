using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Simulation.Model;
using System.Diagnostics;

namespace Simulator
{
    public class SimulationParameters
    {
        public int NumberOfDays;
        public int BlockTimeDurationInMinutes;
        public int SpeedKmH;
        public int RandomPercentage;
    }

    public class ShiftCost : IComparable
    {
        public SimulationShift Shift;
        public SimulationBlockTime BlockTime;
        public Objective Cost;
        public long TravelSeconds;

        public ShiftCost(SimulationShift shift, SimulationBlockTime blocktime, long travel, Objective cost)
        {
            Shift = shift;
            BlockTime = blocktime;
            TravelSeconds = travel;
            Cost = cost;
        }

        public int CompareTo(object obj)
        {
            var other = obj as ShiftCost;
            if (Cost.IsBetterThanOther(other.Cost))
                return -1;

            if (other.Cost.IsBetterThanOther(Cost))
                return 1;

            return Shift.Engineer.Id - other.Shift.Engineer.Id; 
        }
    }

    public class ShiftCostList : List<ShiftCost>
    {
        public ShiftCost GetBest(Random rand)
        {
            if (Count == 0)
                return null;

            // In case there are multiple "best" options, we choose one randomly:
            double[] randoms = new double[Count];
            for (int i = 0; i < Count; ++i)
                randoms[i] = rand.NextDouble();

            var result = this[0];
            int bestIndex = 0;

            for (int i = 1; i < Count; ++i)
            {
                if (this[i].Cost.IsBetterThanOther(result.Cost) || (this[i].Cost.IsSame(result.Cost) && randoms[i] < randoms[bestIndex]))
                {
                    result = this[i];
                    bestIndex = i;
                }
            }

            return result;
        }
    }

    public class Simulation
    {
        public double AssignRandomThreshold { get; set; }
        public ParametrizedStrategy Strategy { get; private set; }
        private Random rand;

        public List<SimulationTask> ScheduledTasks = new List<SimulationTask>();
        public List<SimulationTask> UnscheduledTasks = new List<SimulationTask>();
        public Simulation(int randompercentage, ParametrizedStrategy strategy)
        {
            AssignRandomThreshold = randompercentage / 100.0;
            Strategy = strategy;
        }

        public int VerbosityLevel = 0;

        private List<ShiftCost> GetRandomBlockTimeAndShiftCostForTask(int idxFirstDayOfPlanning, SimulationModel model, SimulationTask task)
        {
            var blocktimes = new List<SimulationBlockTime>();
            // Allow only planning within the deadline:
            int firstIndexForTask = task.IntakeDayIndex + 1;
            int lastIndexForTask = task.Deadline;
            for (int idxDay = firstIndexForTask; idxDay <= lastIndexForTask && idxDay < model.NumberOfDays; ++idxDay)
            {
                foreach (var blocktime in model.BlockTimesPerDay[idxDay])
                {
                    blocktime.TempScore = rand.NextDouble();
                    blocktimes.Add(blocktime);
                }
            }

            // Sort based on new assigned temp score (i.e. randomly):
            blocktimes.Sort();

            var result = new List<ShiftCost>();
            foreach (var blocktime in blocktimes)
            {
                foreach (var shift in model.ShiftsPerDay[blocktime.DayIndex])
                {
                    var objective = Strategy.GetObjectiveForTaskInShift(idxFirstDayOfPlanning, task, shift, blocktime, out long travel);
                    // If the shift can not do the task (according to the stategy), return null as objective:
                    if (objective != null)
                    {
                        var shiftcost = new ShiftCost(shift, blocktime, travel, objective);
                        result.Add(shiftcost);
                    }
                }

                // Pick the first possible blocktime:
                if (result.Count > 0)
                {
                    task.RandomAssignment = true;
                    break;
                }
            }

            return result;
        }

        public void Run(SimulationModel model, ProgressBar progress)
        {
            rand = new Random(model.NumberOfDays);

            // This code studies the switch from travel time based planning to cluster based planning:
            /* 
            =======================================================================================
            long maxTime = model.Employees[0].MaxTravelSecondsBetweenTasks;

            // Test: disable max travels between activities, and switch on empty shift reductions:
            foreach (var employee in model.Employees)
                employee.MaxTravelSecondsBetweenTasks = long.MaxValue;

            Strategy.ReductionPercentageForEmptyShift = new List<int> { 110, 110, 50 };
            =======================================================================================
            */

            progress.Maximum = model.NumberOfDays - 1;
            var waitingList = new SimulationTaskList();

            for (int dayIndex = 0; dayIndex < model.NumberOfDays; ++dayIndex)
            {
                if (VerbosityLevel >= 100)
                {
                    Debug.WriteLine("*********************************************************");
                    Debug.WriteLine($"Start planning day {dayIndex}");
                }

                for (int i = waitingList.Count - 1; i >= 0; --i)
                {
                    var task = waitingList[i];
                    int lastIndex = task.Deadline + Strategy.GetMaxDaysAfterDeadline(task);
                    if (lastIndex <= dayIndex)
                    {
                        waitingList.RemoveAt(i);
                        UnscheduledTasks.Add(task);
                    }
                }

                // This code studies the switch from travel time based planning to cluster based planning:
                if (dayIndex == 20 && Strategy.MaxMinutesBetweenTasks < int.MaxValue)
                {
                    int maxSecondsBetweenTasks = 60 * Strategy.MaxMinutesBetweenTasks;

                    foreach (var employee in model.Employees)
                        employee.MaxTravelSecondsBetweenTasks = maxSecondsBetweenTasks;

                    Strategy.ReductionPercentageForEmptyShift = null;
                }

                progress.Value = dayIndex;

                Application.DoEvents();

                var unhandledTasks = new List<SimulationTask>();
                unhandledTasks.AddRange(waitingList);
                waitingList.Clear();
                if (model.TasksPerDay[dayIndex] != null)
                    unhandledTasks.AddRange(model.TasksPerDay[dayIndex]);

                int firstDayForPlanning = dayIndex + 1;

                var shiftcosts = new ShiftCostList();
                while (unhandledTasks.Count > 0)
                {
                    var task = Strategy.GetTaskToPlan(model, unhandledTasks, dayIndex);
                    if (task == null) // no task can be planned:
                    {
                        if (Strategy.AddNotPlannedToWaitingList)
                            waitingList.AddRange(unhandledTasks);
                        else
                            UnscheduledTasks.AddRange(unhandledTasks);

                        break;
                    }

                    unhandledTasks.Remove(task);
                    shiftcosts.Clear();

                    // First try random order assignment: sort blocktimes randomly, and if a blocktime yields a solution, choose it.
                    // This emulates the customer choosing a time without any attention to what time is good in the existing routes.
                    bool doRandom = rand.NextDouble() < AssignRandomThreshold;
                    if (doRandom)
                    {
                        var shiftcostsublist = GetRandomBlockTimeAndShiftCostForTask(firstDayForPlanning, model, task);
                        shiftcosts.AddRange(shiftcostsublist);
                    }

                    // Choose based on best score in case we do not choose randomly, 
                    // or if the random assignment within the deadline returned no result.
                    if (shiftcosts.Count == 0)
                    {
                        int firstIndex = doRandom ? task.Deadline + 1 : dayIndex + 1;
                        int lastIndex = Strategy is JustInTimeStrategy ? dayIndex + 1 : task.Deadline + Strategy.GetMaxDaysAfterDeadline(task);

                        for (int idxDay = firstIndex; idxDay <= lastIndex && idxDay < model.NumberOfDays; ++idxDay)
                        {
                            foreach (var blocktime in model.BlockTimesPerDay[idxDay])
                            {
                                foreach (var shift in model.ShiftsPerDay[idxDay])
                                {
                                    var objective = Strategy.GetObjectiveForTaskInShift(firstDayForPlanning, task, shift, blocktime, out long travel);
                                    // If the shift can not do the task (according to the stategy), return null as objective:
                                    if (objective != null)
                                    {
                                        var shiftcost = new ShiftCost(shift, blocktime, travel, objective);
                                        shiftcosts.Add(shiftcost);
                                    }
                                }
                            }
                        }
                    }

                    if (shiftcosts.Count == 0)
                    {
                        if (VerbosityLevel >= 1000)
                            Debug.WriteLine($"task {task.Id} (day {task.IntakeDayIndex}) is not planned");

                        UnscheduledTasks.Add(task);
                        continue; // to next task
                    }

                    var selected = Strategy.GetBestShiftForTask(model, task, shiftcosts, rand);
                    Strategy.AddTaskToShift(task, selected);
                    ScheduledTasks.Add(task);

                    if (VerbosityLevel >= 1000)
                        Debug.WriteLine($"task {task.Id} (day {task.IntakeDayIndex}) is assigned to employee {selected.Shift.Engineer.Id} on day {selected.Shift.DayIndex} and blocktime startting at {selected.BlockTime.StartSecond / 60}, objective {selected.Cost}");
                }
            }
        }
    }
}
