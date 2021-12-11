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
                .Aggregate(0, (int count, (int x, int y)position) => count += input[position.y, position.x] + 1);

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
                    var neighbours = array.Neighbours(x, y);

                    if(neighbours.All(((int x, int y)n) => array[n.y, n.x] > array[y,x]))
                    {
                        yield return (x, y);
                    }
                }
            }

            yield break;
        }        

        public static IEnumerable<(int, int)> Basin(this (int, int) point, int[,] array)
        {
            var visited = new HashSet<(int, int)>();
            var queue = new Queue<(int, int)>();

            queue.Enqueue(point);

            while (queue.TryDequeue(out (int x, int y) c))
            {
                if (visited.Contains(c))
                {
                    continue;
                }

                visited.Add(c);

                foreach ((int x, int y) n in array.Neighbours(c.x, c.y))
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
