using System;
using System.Collections.Generic;

namespace Simulation.Model
{
    public class SimulationModel
    {
        public static DateTime FirstDateTime = new DateTime(2020, 1, 1);
        public static int MaxNumberOfDays = 500;
        public int NumberOfDays { get; private set; }
        public int TotalNumberOfTasks { get { return GetTotalNumberOfTasks(); } }
        public int FirstDayWithTasks { get { return GetFirstDayWithTasks(); } }

        public int LastDayWithTasks { get { return GetLastDayWithTasks(); } }
        public List<SimulationTask>[] TasksPerDay = new List<SimulationTask>[MaxNumberOfDays];
        public List<SimulationEngineer> Employees = new List<SimulationEngineer>();
        public List<SimulationShift>[] ShiftsPerDay;
        public List<SimulationBlockTime>[] BlockTimesPerDay;

        private int GetTotalNumberOfTasks()
        {
            int result = 0;
            for (int idxDay = 0; idxDay < MaxNumberOfDays; ++idxDay)
                if (idxDay < TasksPerDay.Length && TasksPerDay[idxDay] != null)
                    result += TasksPerDay[idxDay].Count;

            return result;
        }

        public List<int> GetTooLates(int start, int excludedEnd)
        {
            int[] tooLates = new int[NumberOfDays];
            foreach (var shiftlist in ShiftsPerDay)
                foreach (var shift in shiftlist)
                    foreach (var task in shift.Tasks)
                    {
                        if (task.IntakeDayIndex >= start && task.IntakeDayIndex < excludedEnd)
                        {
                            var idx = Math.Max(0, shift.DayIndex - task.Deadline);
                            tooLates[idx]++;
                        }
                    }

            int lastIndex = Math.Min(4, tooLates.Length - 1);
            for (int i = tooLates.Length - 1; i >= 5; --i)
            {
                if (tooLates[i] != 0)
                {
                    lastIndex = i;
                    break;
                }
            }

            var result = new List<int>();
            for (int i = 0; i <= lastIndex; ++i)
                result.Add(tooLates[i]);

            return result;
        }

        private int GetLastDayWithTasks()
        {
            int result = -1;
            for (int idxDay = 0; idxDay < MaxNumberOfDays; ++idxDay)
                if (idxDay < TasksPerDay.Length && TasksPerDay[idxDay] != null && TasksPerDay[idxDay].Count > 0)
                    result = idxDay;

            return result;
        }

        private int GetFirstDayWithTasks()
        {
            for (int idxDay = 0; idxDay < MaxNumberOfDays; ++idxDay)
                if (idxDay < TasksPerDay.Length && TasksPerDay[idxDay] != null && TasksPerDay[idxDay].Count > 0)
                    return idxDay;

            return -1;
        }

        public void AddTask(string line)
        {
            var task = new SimulationTask(line);
            if (task.IntakeDayIndex >= MaxNumberOfDays)
                throw new Exception($"De dag index is hoger dan SimulationModel.MaxNumberOfDays ({MaxNumberOfDays})");

            if (TasksPerDay[task.IntakeDayIndex] == null)
                TasksPerDay[task.IntakeDayIndex] = new List<SimulationTask> { task };
            else
                TasksPerDay[task.IntakeDayIndex].Add(task);
        }

        public void AddEmployee(string line)
        {
            var employee = new SimulationEngineer(line);
            Employees.Add(employee);
        }

        public void CreateShifts(int numberOfDays)
        {
            NumberOfDays = numberOfDays;
            ShiftsPerDay = new List<SimulationShift>[NumberOfDays];
            foreach (var employee in Employees)
                employee.ShiftsPerDayIndex = new SimulationShift[NumberOfDays];

            for (int idxDay = 0; idxDay < numberOfDays; ++idxDay)
            {
                ShiftsPerDay[idxDay] = new List<SimulationShift>();
                foreach (var employee in Employees)
                {
                    var shift = new SimulationShift(employee, idxDay);
                    ShiftsPerDay[idxDay].Add(shift);
                    employee.ShiftsPerDayIndex[idxDay] = shift;
                }
            }
        }
    
        public void CreateBlockTimes(int numberOfDays, int durationInMinutes)
        {
            int maxval = 525;
            int calcduration = durationInMinutes <= 0 || durationInMinutes > maxval ? maxval : durationInMinutes;
            int numberOfBlocktimesPerday = maxval / calcduration;

            BlockTimesPerDay = new List<SimulationBlockTime>[NumberOfDays];

            for (int idxDay = 0; idxDay < numberOfDays; ++idxDay)
            {
                BlockTimesPerDay[idxDay] = new List<SimulationBlockTime>();
                for (int i = 0; i < numberOfBlocktimesPerday; ++i)
                {
                    var blocktime = new SimulationBlockTime(idxDay, i, i * durationInMinutes, (i + 1) * durationInMinutes);
                    BlockTimesPerDay[idxDay].Add(blocktime);
                }
            }
        }
    }
}
