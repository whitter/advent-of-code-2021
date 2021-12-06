using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day1
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .Select(x => Convert.ToInt32(x));
            
            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(IEnumerable<int> input)
        {
            return input.CountIncreases();
        }

        public static int Task2(IEnumerable<int> input)
        {
            var windowed = input
                .Window(3)
                .Select(x => x.Sum());

            return windowed.CountIncreases();
        }
    }

    public static class Extensions
    {
        public static int CountIncreases(this IEnumerable<int> items)
        {
            return items
                .Pairwise((prev, current) => current > prev)
                .Count(x => x);
        }
    }
}
