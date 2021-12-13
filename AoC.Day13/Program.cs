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

namespace AoC.Day13
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .ToMapAndFolds();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Task2(input);
        }

        public static int Task1(((int, int)[] map, (string, int)[] folds) input)
        {
            var map = input.map.Fold(input.folds[0]);

            return map.Length;
        }

        public static int Task2(((int, int)[] map, (string, int)[] folds) input)
        {
            foreach(var fold in input.folds)
            {
                input.map = input.map.Fold(fold);
            }

            foreach((int x, int y) in input.map)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write('#');
            }

            Console.SetCursorPosition(0, 25);

            return 0;
        }
    }    


    public static class Extensions
    {
        public static ((int, int)[], (string, int)[]) ToMapAndFolds(this string input)
        {
            var regex = new Regex(@"([xy])=(\d*)");

            var sections = input
                .SplitByBlankLine();

            var map = sections[0]
                .SplitByNewline()
                .Select(x => x.ToArray<int>())
                .Select(x => (x[0], x[1]))
                .ToArray();

            var folds = sections[1]
                .SplitByNewline()
                .Select(x => regex.Match(x))
                .Select(x => (x.Groups[1].Value, Convert.ToInt32(x.Groups[2].Value)))
                .ToArray();

            return (map, folds);
        }

        public static (int, int)[] Fold(this (int x, int y)[] map, (string direction, int position) fold)
        {
            if(fold.direction == "y")
            {
                return map
                    .Select(x => x.y < fold.position ? x : (x.x, fold.position * 2 - x.y))
                    .Distinct()
                    .ToArray();
            }

            return map
                    .Select(x => x.x < fold.position ? x : (fold.position * 2 - x.x, x.y))
                    .Distinct()
                    .ToArray();
        }
    }
}
