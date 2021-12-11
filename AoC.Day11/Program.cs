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

namespace AoC.Day11
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .Select(x => x.Select(c => c - '0').ToArray())
                .ToArray()
                .To2DArray();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static long Task1(int[,] input)
        {
            var array = (int[,])input.Clone();

            var flashes = 0L;

            for (int i = 0; i < 100; i++)
            {
                flashes += array.Step();
            }

            return flashes;
        }

        public static long Task2(int[,] input)
        {
            var array = (int[,])input.Clone();

            for (int i = 1; ; i++)
            {
                var flashes = array.Step();

                if (flashes == input.GetLength(0) * input.GetLength(1))
                {
                    return i;
                }
            }            
        }        
    }    


    public static class Extensions
    {
        public static long Step(this int[,] array)
        {
            var flashes = 0L;

            var queue = new Queue<(int x, int y)>();

            void increment(int x, int y)
            {
                var power = ++array[y, x];
                if (power == 10)
                {
                    queue.Enqueue((x, y));
                    flashes++;
                }
            }

            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    increment(x, y);
                }
            }

            while (queue.TryDequeue(out (int x, int y) p))
            {
                foreach ((int x, int y) in array.Adjacents(p.x, p.y))
                {
                    increment(x, y);
                }
            }

            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    if (array[y, x] >= 10)
                    {
                        array[y, x] = 0;
                    }
                }
            }

            return flashes;
        }
    }
}
