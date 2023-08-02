using System;
using System.Diagnostics;

namespace Simulation.Model
{
    public static class DistributionUtilities
    {
        /// <summary>
        /// The chance for values from mean to max are #values * average chance = (max - mean + 1) * 1/2 * (maxChance - minChance)
        /// </summary>
        private static void SetUpperValues(double[] result, int min, int mean, double maxChance, double minChance)
        {
            int max = min + result.Length - 1;
            double stepChance = (maxChance - minChance) / (max - mean);
            double currentChance = maxChance;
            for (int indx = mean - min; indx < result.Length; ++indx)
            {
                result[indx] = currentChance;
                currentChance -= stepChance;
            }
        }

        /// <summary>
        /// The chance for values from mean to max are #values * average chance = (mean + 1) * 1/2 * (maxChance - minChance)
        /// </summary>
        private static void SetLowerValues(double[] result, int min, int mean, double maxChance, double minChance)
        {
            double stepChance = (maxChance - minChance) / (mean - min);
            double currentChance = maxChance;
            for (int indx = mean - min; indx >= 0; --indx)
            {
                result[indx] = currentChance;
                currentChance -= stepChance;
            }
        }

        private static double SumChances(double[] distribution)
        {
            double result = 0.0;
            foreach (var val in distribution)
                result += val;

            return result;
        }

        public static bool CheckDistribution(double[] distribution)
        {
            double error = Math.Abs(1.0 - SumChances(distribution));
            return error < 0.0000001;
        }

        public static double CalculateMean(int min, double[] distribution)
        {
            double sum = 0.0;
            for (int indx = 0; indx < distribution.Length; ++indx)
                sum += (indx + min) * distribution[indx];

            return sum;
        }

        private static double GetLowerAverageChance(double[] distribution, int min, int mean)
        {
            double result = 1.0;
            for (int i = mean - min + 1; i < distribution.Length; ++i)
                result -= distribution[i];

            return result / (mean - min + 1);
        }

        // Distribution on [0,...,N-1], N = 2n + 1 with mean = n. Basic offset for all = 1/N^2 -> leads to 1/N in chance.
        // Chance for n: 2/N.
        // Change for k = 0 to n - 1: k/n* 2/N: sum k = 0 to n-1: (n-1)/N. 
        // For n + 1 to N - 1 also (n-1)/N (symmetric)
        // Sum: 1/N + 2/N + 2 * (n - 1)/N = (2 n + 1)/ N = 1
        public static double[] GetDistribution(int min, int mean, int max)
        {
            if (min == mean)
            {
                Debug.Assert(mean == max);
                return new double[] { 1.0 };
            }

            bool invertRange = mean - min > max - mean;
            if (invertRange)
            {
                int oldmin = min;
                min = - max;
                mean = - mean;
                max = - oldmin;
            }

            Debug.Assert(min < mean && mean < max);
            var distribution = new double[max - min + 1];
            double avgChance = 1.0 / (max - min + 1);
            double offset = 1.0 / (distribution.Length * distribution.Length);
            double maxChance = 2 * avgChance + offset;
            SetUpperValues(distribution, min, mean, maxChance, offset);
            double lowerAvgChance = GetLowerAverageChance(distribution, min, mean);
            double minChance = lowerAvgChance - (maxChance - lowerAvgChance);
            SetLowerValues(distribution, min, mean, maxChance, minChance);
            Debug.Assert(CheckDistribution(distribution));

            double delta = 0.01;
            double calcMean = CalculateMean(min, distribution);
            while (calcMean >= mean + 0.05)
            {
                maxChance -= delta / distribution.Length;
                SetUpperValues(distribution, min, mean, maxChance, offset);
                lowerAvgChance = GetLowerAverageChance(distribution, min, mean);
                minChance = lowerAvgChance - (maxChance - lowerAvgChance);
                SetLowerValues(distribution, min, mean, maxChance, minChance);
                Debug.Assert(CheckDistribution(distribution));
                calcMean = CalculateMean(min, distribution);
            }

            var result = new double[distribution.Length];

            if (invertRange)
            {
                min = -max;
                mean = -mean;
                for (int i = 0; i < distribution.Length; ++i)
                    result[i] = distribution[distribution.Length - 1 - i];
            }
            else
                for (int i = 0; i < distribution.Length; ++i)
                    result[i] = distribution[i];

            CheckDistribution(result);
            double meanError = Math.Abs(mean - CalculateMean(min, result));
            Debug.Assert(meanError <= 0.1);

            return result;
        }
    }
}
