using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day2
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .Select(x => {
                    var line = x.Split(' ');

                    return (line[0], Convert.ToInt32(line[1]));
                });
            
            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static int Task1(IEnumerable<(string, int)> input)
        {
            (int x, _, int d) = CalcPosition(input);

            return x * d;
        }

        public static int Task2(IEnumerable<(string, int)> input)
        {
            (int x, int y, _) = CalcPosition(input);

            return x * y;
        }

        public static (int, int, int) CalcPosition(IEnumerable<(string, int)> input)
        {
            (int X, int Y, int D) position = (0, 0, 0);

            foreach((string direction, int value) in input)
            {
                switch(direction)
                {
                    case "forward":
                        position.X += value;
                        position.Y += position.D * value;
                        break;
                    case "up":
                        position.D -= value;
                        break;
                    case "down":
                        position.D += value;
                        break;
                }
            }

            return position;
        }
    }
}
