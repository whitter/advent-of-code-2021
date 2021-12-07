using AoC.Common;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Day7
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
               .ToArray<double>();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(double[] input)
        {
            var median = (int)input.Median();

            return input.Sum(x => Math.Abs((int)x - median));
        }

        public static int Task2(double[] input)
        {
            var mean = input.Mean();

            return Math.Min(input.CalculateFuel((int)Math.Floor(mean)), input.CalculateFuel((int)Math.Ceiling(mean)));
        }
    }    

    public static class Extensions
    {
        public static int CalculateFuel(this double[] input, int mean)
        {
            return input
                .Sum(x =>
                {
                    var diff = Math.Abs((int)x - mean);

                    return diff * (diff + 1) / 2;
                });
        }
    }
}
