using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string content;

            using(var reader = new StreamReader("input.txt"))
            {
                content = reader.ReadToEnd();
            }

            var input = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToInt32(x));
            
            Console.WriteLine($"Task 1: {Task1.Process(input)}");
            Console.WriteLine($"Task 2: {Task2.Process(input)}");
        }        
    }

    public static class Task1
    {
        public static int Process(IEnumerable<int> input)
        {
            return input.CountIncreases();
        }
    }

    public static class Task2
    {
        public static int Process(IEnumerable<int> input)
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
