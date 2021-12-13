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
using System.Text;
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
            Console.WriteLine($"Task 2:");
            Console.WriteLine(Task2(input));
        }

        public static int Task1(((int, int)[] map, (string, int)[] folds) input)
        {
            var map = input.map.Fold(input.folds[0]);

            return map.Length;
        }

        public static string Task2(((int, int)[] map, (string, int)[] folds) input)
        {
            foreach (var fold in input.folds)
            {
                input.map = input.map.Fold(fold);
            }

            var map = input.map.ToMap();

            var sb = new StringBuilder();

            for (var y = 0; y < map.GetLength(0); y++)
            {
                sb.AppendLine(string.Join("", map.SliceRow(y)));
            }

            return sb.ToString();
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

        public static char[,] ToMap(this (int x, int y)[] map, char character = '#')
        {
            var xLength = map.Max(x => x.x) + 1;
            var yLength = map.Max(x => x.y) + 1;

            var _map = new char[yLength, xLength];

            for (int row = 0; row < _map.GetLength(0); row++)
            {
                for (int column = 0; column < _map.GetLength(1); column++)
                {
                    _map[row, column] = ' ';
                }
            }

            foreach ((int x, int y) in map)
            {
                _map[y, x] = character;
            }

            return _map;
        }
    }
}
