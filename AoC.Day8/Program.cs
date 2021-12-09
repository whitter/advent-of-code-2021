using AoC.Common;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC.Day8
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
               .SplitByNewline()
               .Select(x => x.ToDigits());

            Console.WriteLine($"Task 1: {input.Sum(x => x.Item1)}");
            Console.WriteLine($"Task 2: {input.Sum(x => x.Item2)}");
        }
    }    

    public static class Extensions
    {
        public static (int, int) ToDigits(this string input)
        {
            int[] patterns = new int[10];
            Dictionary<int, int> digits = new Dictionary<int, int>();

            void set(int bits, int number)
            {
                digits.Add(bits, number);
                patterns[number] = bits;
            }

            var _input = input
                .ToArray<string>('|')
                .Select(x => x.ToArray<string>(' ').Select(p => (p.Length, p.ToBits())).ToArray())
                .ToArray();

            foreach ((int length, int bits) in _input[0])
            {
                switch(length)
                {
                    case 2:
                        set(bits, 1);
                        break;
                    case 3:
                        set(bits, 7);
                        break;
                    case 4:
                        set(bits, 4);
                        break;
                    case 7:
                        set(bits, 8);
                        break;
                }
            }

            foreach ((int length, int bits) in _input[0])
            {
                switch (length)
                {
                    case 5:
                        if ((bits | patterns[4]) == patterns[8])
                        {
                            set(bits, 2);
                        }
                        else if ((bits & patterns[1]) == patterns[1])
                        {
                            set(bits, 3);
                        }
                        else
                        {
                            set(bits, 5);
                        }
                        break;
                    case 6:
                        if ((bits & patterns[4]) == patterns[4])
                        {
                            set(bits, 9);
                        }
                        else if ((bits & patterns[1]) == patterns[1])
                        {
                            set(bits, 0);
                        }
                        else
                        {
                            set(bits, 6);
                        }
                        break;
                }
            }

            int count = 0;
            int number = 0;

            foreach((_, int bits) in _input[1])
            {
                int digit = digits[bits];

                number = (number * 10) + digit;

                switch(digit)
                {
                    case 1:
                    case 4:
                    case 7:
                    case 8:
                        count++;
                        break;
                }
            }

            return (count, number);
        }

        private static int ToBits(this string pattern)
        {
            var bits = 0;

            foreach (var c in pattern)
            {
                bits |= 1 << c - 'a';
            }

            return bits;
        }
    }
}
