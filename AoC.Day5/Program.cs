using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Day5
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .Select(Line.Parse);

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(IEnumerable<Line> input)
        {
            return input
                .Where(x => !x.IsDiagonal)
                .SelectMany(x => x.ToPoints())
                .GroupBy(x => x)
                .Where(x => x.Count() >= 2)
                .Count();
        }

        public static int Task2(IEnumerable<Line> input)
        {
            return input
                .SelectMany(x => x.ToPoints())
                .GroupBy(x => x)
                .Where(x => x.Count() >= 2)
                .Count();
        }
    }

    public class Line
    {
        private Point p1;
        private Point p2;

        public static Line Parse(string input)
        {
            var points = Regex.Matches(input, @"(\d+)")
                .Select(x => int.Parse(x.Value))
                .ToArray();

            return new Line
            {
                p1 = new Point(points[0], points[1]),
                p2 = new Point(points[2], points[3])
            };
        }

        public IEnumerable<Point> ToPoints()
        {
            int dx = Math.Sign(p2.X - p1.X);
            int dy = Math.Sign(p2.Y - p1.Y);

            int x = p1.X;
            int y = p1.Y;

            while (!(x == p2.X && y == p2.Y))
            {
                yield return new Point(x, y);
                x += dx;
                y += dy;
            }

            yield return new Point(x, y);
        }

        public bool IsDiagonal => p1.X != p2.X && p1.Y != p2.Y;
    }

    public static class Extensions
    {
    }
}
