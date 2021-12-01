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
            
            Console.WriteLine($"Task 1: {input.Pairwise((prev, current) => current > prev).Where(x => x).Count()}");
            Console.WriteLine($"Task 2: {input.Window(3).Select(x => x.Sum()).Pairwise((prev, current) => current > prev).Where(x => x).Count()}");
        }
    }
}
