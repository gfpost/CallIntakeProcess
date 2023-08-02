using System;

namespace Simulation.Model
{
    public class SimulationObject
    {
        public int Id { get; set; }
        public int[] Coordinates { get; internal set; }
        protected void SetCoordinates(string coords)
        {
            var splitcoords = coords.Split(',');
            Coordinates = new int[] { Convert.ToInt32(splitcoords[0]), Convert.ToInt32(splitcoords[1]) };
        }
    }
}
