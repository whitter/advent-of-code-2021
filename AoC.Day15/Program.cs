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

namespace AoC.Day15
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static long Task1(string input)
        { 
            var map = input
                .SplitByNewline()
                .Select(x => x.Select(c => new Node { Weight = c - '0' }).ToArray())
                .ToArray()
                .To2DArray();

            return map.Dijkstra((0, 0), (map.GetLength(1) - 1, map.GetLength(0) - 1));
        }

        public static long Task2(string input)
        {
            var map = input
                .SplitByNewline()
                .Select(x => x.Select(c => new Node { Weight = c - '0' }).ToArray())
                .ToArray()
                .To2DArray();

            var expanded = new Node[map.GetLength(0) * 5, map.GetLength(1) * 5];

            for (int offsetY = 0; offsetY < 5; offsetY++)
            {
                for (int offsetX = 0; offsetX < 5; offsetX++)
                {
                    for (int y = 0; y < map.GetLength(0); y++)
                    {
                        for (int x = 0; x < map.GetLength(1); x++)
                        {
                            var new_x = x + offsetX * map.GetLength(0);
                            var new_y = y + offsetY * map.GetLength(1);

                            expanded[new_y, new_x] = new Node { Weight = (map[y, x].Weight + offsetY + offsetX - 1) % 9 + 1 };
                        }
                    }
                }
            }

            return expanded.Dijkstra((0, 0), (expanded.GetLength(1) - 1, expanded.GetLength(0) - 1));
        }
    }    

    public class Node
    {
        public int Distance { get; set; } = int.MaxValue;
        public bool Visited { get; set; } = false;
        public int Weight { get; set; }
    }

    public static class Extensions
    {
        public static int Dijkstra<T>(this T[,] map, (int x, int y) start, (int x, int y) end) where T : Node
        {
            var queue  = new PriorityQueue<(int, int), int>();

            map[start.y, start.x].Distance = 0;

            queue.Enqueue(start, 0);

            while(queue.TryDequeue(out (int x, int y) position, out _))
            {
                if(map[position.y, position.x].Visited)
                {
                    continue;
                }

                map[position.y, position.x].Visited = true;

                if(position == end)
                {
                    return map[end.y, end.x].Distance;
                }

                foreach((int x, int y) in map.Neighbours(position.x, position.y))
                {
                    if (map[y, x].Visited)
                    {
                        continue;
                    }

                    var distance = map[position.y, position.x].Distance + map[y, x].Weight;

                    if(distance < map[y, x].Distance)
                    {
                        map[y, x].Distance = distance;
                    }

                    if(map[y, x].Distance != int.MaxValue)
                    {
                        queue.Enqueue((x, y), map[y, x].Distance);
                    }
                }
            }

            return map[end.y, end.x].Distance;
        }
    
        public static T[,] Resize<T>(this T[,] array, int x, int y)
        {
            var result = new T[x, y];

            int minX = Math.Min(array.GetLength(0), result.GetLength(0));
            int minY = Math.Min(array.GetLength(1), result.GetLength(1));

            for (int i = 0; i < minY; ++i)
                Array.Copy(array, i * array.GetLength(0), result, i * result.GetLength(0), minX);

            return result;
        }
    }
}
