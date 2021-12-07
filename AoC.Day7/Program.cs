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
               .ToIntArray()
               .Select(x => (double)x)
               .ToArray();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static double Task1(double[] input)
        {
            var m = input.Median();

            return input.Sum(x => Math.Abs(x - m));
        }

        public static double Task2(double[] input)
        {
            return 0;
        }
    }    

    public static class Extensions
    {
    }
}
