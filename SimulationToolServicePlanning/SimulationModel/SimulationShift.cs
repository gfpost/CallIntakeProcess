using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Simulation.Model
{
    public class SimulationShift
    {
        public static int MaxNumberOfTasks = 25;
        public int DayIndex { get; private set; }
        public SimulationEngineer Engineer { get; private set; }
        public long DurationInSeconds { get; private set; }
        public SimulationTaskList Tasks = new SimulationTaskList();
        public long TotalTravelTimeInSeconds;
        public long TotalTaskDurationInSeconds;
        public readonly long[] FirstTaskStarts;
        public readonly long[] LastTaskStarts;
        public long[] TravelTimeBetweenTasks;

        public SimulationShift(SimulationEngineer employee, int dayindex)
        {
            DayIndex = dayindex;
            Engineer = employee;
            DurationInSeconds = 60 * employee.ShiftDurationInMinutes;
            TotalTravelTimeInSeconds = 0;
            FirstTaskStarts = new long[MaxNumberOfTasks];
            LastTaskStarts = new long[MaxNumberOfTasks];
        }

        public bool CanDoTask(SimulationTask task, int firstDayOfPlanning, int firstDayForMaximumTravelCheck)
        {
            if (!Engineer.CanDoTask(task))
                return false;

            if (Engineer.MaxTravelSecondsBetweenTasks < int.MaxValue && DayIndex - firstDayOfPlanning >= firstDayForMaximumTravelCheck)
            {
                return CheckMaxTravelTimeBetweenTasks(task);
            }

            return true;
        }

        private bool CheckMaxTravelTimeBetweenTasks(SimulationTask task)
        {
            // The check is passed, when there are no activities in the shift:
            if (Tasks.Count == 0)
                return true;

            long maxTime = Engineer.MaxTravelSecondsBetweenTasks;
            if (maxTime == long.MaxValue || maxTime == 0)
                return true;

            // Determine which points are close to the unassigned point:
            var closeToUnassigned = GetIndicesOfPlannedTasksNearTask(task, maxTime);

            // reject, if the unassigned is not near any input activity:
            if (closeToUnassigned.Count == 0)
                return false;

            // accept, if the unassigned is near all input activities:
            if (closeToUnassigned.Count == Tasks.Count)
                return true;

            // If can happen that the input activities are not in one cluster;
            // in that case we require that the unassigned activity is near the farther activity, but IN ADDITION near to all activities near to the farthest!
            // If the unassigned activity is not near the farthest point, we reject it:
            var indexFarthest = GetIndexOfFarthestTask();
            if (!closeToUnassigned.Contains(indexFarthest))
                return false;

            // Only if the unassigned activity is near all point near to the farthest, we accept it:
            var farthestTask = Tasks[indexFarthest];
            var closeToFarthest = GetIndicesOfPlannedTasksNearTask(farthestTask, maxTime);
            foreach (int idxActivity in closeToFarthest)
            {
                if (!closeToUnassigned.Contains(idxActivity))
                    return false;
            }

            // It was near to all points near to the farthest so accept:
            return true;
        }

        private List<int> GetIndicesOfPlannedTasksNearTask(SimulationTask task, long maxTravelTime)
        {
            var result = new List<int>();

            for (int i = 0; i < Tasks.Count; ++i)
            {
                var plannedTask = Tasks[i];

                if (plannedTask == task)
                    continue;

                var time = TravelTimes.TravelTimeBetween(plannedTask, task);

                if (time <= maxTravelTime)
                    result.Add(i);
            }

            return result;
        }

        private int GetIndexOfFarthestTask()
        {
            int result = -1;
            long longestTime = -1;

            for (int i = 0; i < Tasks.Count; ++i)
            {
                var task = Tasks[i];
                var time = TravelTimes.TravelTimeBetween(Engineer, task);
                if (time > longestTime)
                {
                    result = i;
                    longestTime = time;
                }
            }

            return result;
        }



        public bool CanInsertTaskAtIndex(SimulationTask task, int insertIndex, SimulationBlockTime blocktime, out long detour)
        {
            Debug.Assert(Engineer.CanDoTask(task));
            Debug.Assert(insertIndex <= Tasks.Count);

            detour = long.MaxValue;

            var startpoint = insertIndex == 0 ? (SimulationObject)Engineer : Tasks[insertIndex - 1];
            var prevFirstFinish = insertIndex == 0 ? 0 : FirstTaskStarts[insertIndex - 1] + Tasks[insertIndex - 1].DurationInSeconds;
            var travelTo = TravelTimes.TravelTimeBetween(startpoint, task);
            var firstStart = prevFirstFinish + travelTo;
            if (firstStart > blocktime.EndSecond)
                return false;

            var endpoint = insertIndex == Tasks.Count ? (SimulationObject)Engineer : Tasks[insertIndex];
            var nextLastStart = insertIndex == Tasks.Count ? this.DurationInSeconds : LastTaskStarts[insertIndex];
            var travelFrom = TravelTimes.TravelTimeBetween(task, endpoint);
            var lastStart = nextLastStart - travelFrom - task.DurationInSeconds;
            if (lastStart < blocktime.StartSecond || lastStart < firstStart)
                return false;

            detour = travelTo + travelFrom - TravelTimes.TravelTimeBetween(startpoint, endpoint);
            return true;
        }

        public void CalculateTravelTimesAndSetFirstAndLastStarts()
        {
            Debug.Assert(Tasks.Count <= MaxNumberOfTasks);
            // Find all travel times (and the sum as result):
            TotalTravelTimeInSeconds = 0;
            TotalTaskDurationInSeconds = 0;
            SimulationObject startObject = Engineer;
            TravelTimeBetweenTasks = new long[Tasks.Count + 1];

            for (int i = 0; i < Tasks.Count; ++i)
            {
                var task = Tasks[i];
                TotalTaskDurationInSeconds += task.DurationInSeconds;
                var traveltime = TravelTimes.TravelTimeBetween(startObject, task);
                TravelTimeBetweenTasks[i] = traveltime;
                TotalTravelTimeInSeconds += traveltime;
                startObject = task;
            }

            var travelhome = TravelTimes.TravelTimeBetween(startObject, Engineer);
            TravelTimeBetweenTasks[Tasks.Count] = travelhome;
            TotalTravelTimeInSeconds += travelhome;

            // Set the first starts:
            long prevFirstFinish = 0;
            for (int i = 0; i < Tasks.Count; ++i)
            {
                var task = Tasks[i];
                var firstStart = Math.Max(prevFirstFinish + TravelTimeBetweenTasks[i], task.BlockTime.StartSecond);
                Debug.Assert(firstStart <= task.BlockTime.EndSecond);
                FirstTaskStarts[i] = firstStart;
                prevFirstFinish = firstStart + task.DurationInSeconds;
            }

            // Set the last starts:
            long nextLastStart = DurationInSeconds;
            for (int i = Tasks.Count - 1; i >= 0 ; --i)
            {
                var task = Tasks[i];
                var lastStart = Math.Min(nextLastStart - TravelTimeBetweenTasks[i + 1] - task.DurationInSeconds, task.BlockTime.EndSecond);
                Debug.Assert(lastStart >= task.BlockTime.StartSecond);
                LastTaskStarts[i] = lastStart;
                Debug.Assert(FirstTaskStarts[i] <= LastTaskStarts[i]);
                nextLastStart = lastStart;
            }

            Debug.Assert(TotalTaskDurationInSeconds + TotalTravelTimeInSeconds <= DurationInSeconds);
            if (Tasks.Count > 1)
                Debug.Assert(FirstTaskStarts[Tasks.Count - 1] + TravelTimeBetweenTasks[Tasks.Count] <= DurationInSeconds);
        }

        public long CalculateDetour(SimulationTask task, int insertIndex)
        {
            Debug.Assert(insertIndex <= Tasks.Count);
            var startpoint = insertIndex == 0 ? (SimulationObject) Engineer : Tasks[insertIndex - 1];
            var endpoint = insertIndex == Tasks.Count ? (SimulationObject)Engineer : Tasks[insertIndex];
            return TravelTimes.TravelTimeBetween(startpoint, task) + TravelTimes.TravelTimeBetween(task, endpoint) - TravelTimes.TravelTimeBetween(startpoint, endpoint);
        }

        public void AddTaskAtIndex(SimulationTask task, int insertIndex)
        {
            Tasks.Insert(insertIndex, task);
            CalculateTravelTimesAndSetFirstAndLastStarts();
        }
    }
}
