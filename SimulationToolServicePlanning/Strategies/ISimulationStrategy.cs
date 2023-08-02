using System;
using System.Collections.Generic;
using Simulation.Model;

namespace Simulator
{
    public interface ISimulationStrategy
    {
        SimulationTask GetTaskToPlan(SimulationModel model, List<SimulationTask> tasks, int dayIndex);
        Objective GetObjectiveForTaskInShift(int idxFirstDayOfPlanning, SimulationTask task, SimulationShift shift, SimulationBlockTime blocktime, out long travel);
        ShiftCost GetBestShiftForTask(SimulationModel model, SimulationTask task, ShiftCostList shiftcosts, Random rand);
        int GetMaxDaysAfterDeadline(SimulationTask task);
        void AddTaskToShift(SimulationTask task, ShiftCost shiftcost);
    }
}
