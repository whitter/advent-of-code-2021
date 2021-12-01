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
            
            Console.WriteLine($"Task 1: {CountIncreases(input)}");
            Console.WriteLine($"Task 2: {CountIncreases(input.Window(3).Select(x => x.Sum()))}");
        }

        private static int CountIncreases(IEnumerable<int> items)
        {
            return items.Pairwise((prev, current) => current > prev).Count(x => x);
        }
    }
}
