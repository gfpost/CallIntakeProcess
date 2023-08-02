using System;
using System.Diagnostics;

namespace Simulation.Model
{
    public static class TravelTimes
    {
        public static double[] DistancesPerFrac = null;
        public static double SpeedKmH = 60.0;

        public static void Precalculate()
        {
            DistancesPerFrac = new double[1001];
            for (int f = 0; f <= 1000; ++f)
            {
                double frac = f / 1000.0;
                DistancesPerFrac[f] = 1000000 * Math.Sqrt(1 + frac);
            }
        }

        public static double GetVectorLength(int x, int y)
        {
            if (DistancesPerFrac == null)
                Precalculate();

            if (x == 0 && y == 0)
                return 0;

            int z = Math.Max(x, y);
            double frac = x > y ? (1000.0 * y * y) / (x * x) : (1000.0 * x * x) / (y * y);
            int f = (int)frac;
            double rem = frac - f;
            Debug.Assert(rem >= 0 && rem <= 1);

            // Use linear interpolation:
            int fnext = f < DistancesPerFrac.Length - 1 ? f + 1 : f;
            return z * ((1 - rem) * DistancesPerFrac[f] + rem * DistancesPerFrac[fnext]) / 1000000.0;
        }

        public static long TravelTimeBetween(SimulationObject from, SimulationObject to)
        {
            if (DistancesPerFrac == null)
                Precalculate();

            int x = Math.Abs(from.Coordinates[0] - to.Coordinates[0]);
            int y = Math.Abs(from.Coordinates[1] - to.Coordinates[1]);

            double distance = GetVectorLength(x, y);

            // long result1 = (long)Math.Round(3600.0 * Math.Sqrt(x * x + y * y) / SpeedKmH, 0);

            // Get travel time in seconds, not in hours:
            long result = (long) Math.Round(3600 * distance / SpeedKmH, 0);
            // checked for many travels: Debug.Assert(result1 == result);

            return result;
        }
    }
}
