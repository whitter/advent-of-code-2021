using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day2
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .Select(x => Convert.ToInt32(x));
            
            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(IEnumerable<int> input)
        {
            return 0;
        }

        public static int Task2(IEnumerable<int> input)
        {
            return 0;
        }
    }
}
