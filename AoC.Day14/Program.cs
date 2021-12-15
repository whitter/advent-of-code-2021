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

namespace AoC.Day14
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByBlankLine();

            var template = input[0];

            Dictionary<string, (string p, long c)> pairs = input[1]
                .ToPairs(template);

            Console.WriteLine($"Task 1: {Task1(pairs, template)}");
            Console.WriteLine($"Task 2: {Task2(pairs, template)}");
        }

        public static long Task1(Dictionary<string, (string p, long c)> input, string template)
        {
            return input.Process(10, template);
        }

        public static long Task2(Dictionary<string, (string p, long c)> input, string template)
        {
            return input.Process(40, template);
        }
    }    

    public static class Extensions
    {
        public static Dictionary<string, (string, long)> ToPairs(this string array, string template)
        {
            Dictionary<string, (string p, long c)> pairs = array
                .SplitByNewline()
                .Select(x => x.Split(" -> ", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => x[0], x => (x[1], 0L));

            var ploys = template.ZipShortest(template[1..], (f, s) => $"{f}{s}");

            foreach(var poly in ploys)
            {
                pairs[poly] = (pairs[poly].p, pairs[poly].c + 1);
            }

            return pairs;
        }

        public static long Process(this Dictionary<string, (string p, long c)> pairs, int steps, string template)
        {
            var _pairs = pairs.ToDictionary(x => x.Key, x => x.Value);

            for (var i = 0; i < steps; i++)
            {
                var copy = _pairs.Where(x => x.Value.c > 0).ToDictionary(x => x.Key, x => x.Value);

                foreach (var pair in copy)
                {
                    var left = pair.Key[0] + pair.Value.p;
                    _pairs[left] = (_pairs[left].p, _pairs[left].c + pair.Value.c);

                    var right = pair.Value.p + pair.Key[1];
                    _pairs[right] = (_pairs[right].p, _pairs[right].c + pair.Value.c);

                    _pairs[pair.Key] = (_pairs[pair.Key].p, _pairs[pair.Key].c - pair.Value.c);
                }
            }

            var counts = _pairs.GroupBy(x => x.Key[1], x => x.Value.c).ToDictionary(x => x.Key, x => x.Sum());

            counts[template[0]]++;

            return counts.Max(x => x.Value) - counts.Min(x => x.Value);
        }
    }
}
