using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day3
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .Select(x => Convert.ToInt32(x, 2));
            
            Console.WriteLine($"Task 1: {Task1(input, 12)}");
            Console.WriteLine($"Task 2: {Task2(input, 12)}");
        }

        public static int Task1(IEnumerable<int> input, int bitLength)
        {
            var most = input.MostBits(bitLength);

            return most * most.InvertBits(bitLength);
        }

        public static int Task2(IEnumerable<int> input, int bitLength)
        {
            return input.ToRating(bitLength, false) * input.ToRating(bitLength, true);
        }        
    }
    public static class Extensions
    {
        public static int ToRating(this IEnumerable<int> input, int bitLength, bool invert)
        {
            IEnumerable<int> rating = input.ToList();

            for (var i = 1 << bitLength - 1; i >= 1; i >>= 1)
            {
                if (rating.Count() == 1) break;

                var flag = rating.GetCommonBit(i, invert);

                rating = rating.Where(x => (x & i) == flag).ToList();
            }

            return rating.First();
        }

        public static int GetCommonBit(this IEnumerable<int> input, int bit, bool invert = false)
        {
            var agg = input.Aggregate(0, (count, n) => count + ((n & bit) == bit ? 1 : 0));

            if (invert)
            {
                return Convert.ToInt32(!(agg >= input.Count() / 2d)) * bit;
            }
            else
            {
                return Convert.ToInt32(agg >= input.Count() / 2d) * bit;
            }
        }

        public static int MostBits(this IEnumerable<int> input, int bitLength)
        {
            int count = 0;

            for (var i = 1 << bitLength - 1; i >= 1; i >>= 1)
            {
                count += input.GetCommonBit(i);
            }

            return count;
        }

        public static int InvertBits(this int input, int bitLength)
        {
            return (1 << bitLength) - input - 1;
        }
    }
}
