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
                .Select(x => x.Select(c=> c - '0').ToArray())
                .ToArray()
                .To2DArray();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(int[,] input)
        {
            var lowest = input
                .ToLowest()
                .Aggregate(0, (int count, (int y, int x)position) => count += input[position.y, position.x] + 1);

            return lowest;
        }

        public static int Task2(int[,] input)
        {
            var basins = input
                .ToLowest()
                .Select(x => x.Basin(input));
            
            return basins
                .Select(x => x.Count())
                .OrderByDescending(x => x)
                .Take(3)
                .Aggregate(1, (count, basin) => count *= basin);
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

                    if(neighbours.All(((int y, int x)n) => array[n.y, n.x] > array[y,x]))
                    {
                        yield return (y, x);
                    }
                }
            }

            yield break;
        }

        public static IEnumerable<(int, int)> Neighbours<T>(this T[,] array, int y, int x)
        {
            var deltas = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            foreach((int dy, int dx) in deltas)
            {
                if((y + dy < 0 || y + dy > array.GetLength(0) - 1) || (x + dx < 0 || x + dx > array.GetLength(1) - 1))
                {
                    continue;
                }

                yield return (y + dy, x + dx);
            }

            yield break;
        }

        public static IEnumerable<(int, int)> Basin(this (int, int) point, int[,] array)
        {
            var visited = new HashSet<(int, int)>();
            var queue = new Queue<(int, int)>();

            queue.Enqueue(point);

            while (queue.Count > 0)
            {
                (int y, int x) c = queue.Dequeue();

                if (visited.Contains(c))
                {
                    continue;
                }

                visited.Add(c);

                foreach ((int y, int x) n in array.Neighbours(c.y, c.x))
                {
                    if (visited.Contains(n))
                        continue;

                    if (array[n.y, n.x] < 9)
                        queue.Enqueue(n);
                }
            }

            return visited;
        }
    }
}
