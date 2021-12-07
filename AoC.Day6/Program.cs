using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Day6
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
               .ToArray<int>()
               .ToDays();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static long Task1(long[] input)
        {
            var days = ProcessDays(input, 80);

            return days.Sum();
        }

        public static long Task2(long[] input)
        {
            var days = ProcessDays(input, 256);

            return days.Sum();
        }

        private static long[] ProcessDays(long[] input, int days)
        {
            for (int i = 0; i < days; i++)
            {
                input = input.ShiftLeft();

                input[6] += input[8];
            }

            return input;
        }
    }    

    public static class Extensions
    {
        public static long[] ToDays(this int[] input)
        {
            var days = new long[9];

            foreach(var fish in input)
            {
                days[fish]++;
            }

            return days;
        }

        public static T[] ShiftLeft<T>(this T[] array)
        {
            T[] temp = new T[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                temp[i] = array[i + 1];
            }

            temp[^1] = array[0];

            return temp;
        }
    }
}
