using System.Linq;
using Simulation.Model;

namespace Simulator
{
    public class MinimumTravelToTimeAtEndOfShiftStrategy : ParametrizedStrategy
    {
        public override Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel)
        {
            travel = long.MaxValue;
            if (!shift.CanDoTask(task, idxFirstDayOfPlanning, FirstDayForMaximumTravelTimeCheck))
                return null;

            if (!shift.CanInsertTaskAtIndex(task, shift.Tasks.Count, blocktime, out long dummy))
                return null;

            // Calculate the traveltotime:
            var startPoint = shift.Tasks.Count == 0 ? (SimulationObject) shift.Engineer : shift.Tasks.Last();
            long travelto = TravelTimes.TravelTimeBetween(startPoint, task);
            travelto = GetAdjustedTravelTimeForDay(shift, idxFirstDayOfPlanning, travelto);
            int latenessPenalty = GetPenaltyForLateness(shift.DayIndex - task.Deadline);
            return new Objective(latenessPenalty, travelto, shift.DayIndex, blocktime.IndexOnDay);
        }

        /// <summary>
        /// Add task at the end!
        /// </summary>
        public override void AddTaskToShift(SimulationTask task, ShiftCost shiftcost)
        {
            task.BlockTime = shiftcost.BlockTime;
            var shift = shiftcost.Shift;
            shift.AddTaskAtIndex(task, shift.Tasks.Count);
        }

        public override string ToString()
        {
            return "Minimum travel time to (end of shift)";
        }
    }
}
