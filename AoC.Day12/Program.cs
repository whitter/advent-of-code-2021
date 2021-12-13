using AoC.Common;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Day12
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .ToPaths();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(ILookup<string, string> input)
        {
            return CountPaths(input, (p, v) => !p.IsSmallCave() || v.GetValueOrDefault(p) == 0);
        }

        public static int Task2(ILookup<string, string> input)
        {
            return CountPaths(input, (p, v) => {
                if (p == "start" || p == "end")
                {
                    return v.GetValueOrDefault(p) == 0;
                }

                if (p.IsSmallCave())
                {
                    return v.GetValueOrDefault(p) == 0 || !v.Any(x => x.Key.IsSmallCave() && x.Value > 1);
                }

                return true;
            });
        }

        private static int CountPaths(
            ILookup<string, string> paths, 
            Func<string, Dictionary<string, int>, bool> visitable, 
            string from = "start", 
            string to = "end", 
            Dictionary<string, int> visited = default)
        {
            if(from == to)
            {
                return 1;
            }

            if(visited == null)
            {
                visited = new Dictionary<string, int>();
            }

            visited[from] = visited.GetValueOrDefault(from) + 1;

            var result = paths[from]
                .Where(p => visitable(p, visited))
                .Sum(p => CountPaths(paths, visitable, p, to, visited));

            visited[from]--;

            return result;
        }
    }    


    public static class Extensions
    {
        public static ILookup<string, string> ToPaths(this string[] array)
        {
            return array
                .Select(x=> x.ToArray<string>('-'))
                .SelectMany(x => new[] { (x[0], x[1]), (x[1], x[0]) })
                .ToLookup(((string from, string to)x) => x.from, ((string from, string to) x) => x.to);
        }

        public static bool IsSmallCave(this string cave)
        {
            return cave.All(char.IsLower);
        }
    }
}
