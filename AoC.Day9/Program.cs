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

namespace AoC.Day9
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .Select(x => x.ToArray<int>(null))
                .ToArray()
                .To2DArray();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(int[,] input)
        {
            var lowest = input
                .ToLowest()
                .Aggregate(0, (count, position) => count += input[position.Item1, position.Item2] + 1);

            return lowest;
        }

        public static int Task2(int[,] input)
        {
            return 0;
        }
    }    

    public static class Extensions
    {
        public static IEnumerable<(int, int)> ToLowest(this int[,] array)
        {
            for(var y = 0; y < array.GetLength(0); y++)
            {
                for(var x = 0; x < array.GetLength(1); x++)
                {
                    var neighbours = array.Neighbours(y, x);

                    if(neighbours.All(p => p > array[y,x]))
                    {
                        yield return (y, x);
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<T> Neighbours<T>(this T[,] array, int y, int x)
        {
            var deltas = new (int, int)[] { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };

            foreach((int dy, int dx) in deltas)
            {
                if((y + dy < 0 || y + dy > array.GetLength(0) - 1) || (x + dx < 0 || x + dx > array.GetLength(1) - 1))
                {
                    continue;
                }

                yield return array[y + dy, x + dx];
            }

            yield break;
        }
    }
}
