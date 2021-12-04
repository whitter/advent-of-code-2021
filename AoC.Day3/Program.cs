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
                .SplitByNewline()
                .Select(x => Convert.ToUInt32(x, 2));
            
            Console.WriteLine($"Task 1: {Task1(input, 12)}");
            Console.WriteLine($"Task 2: {Task2(input, 12)}");
        }

        public static uint Task1(IEnumerable<uint> input, int bitLength)
        {
            var most = input.MostBits(bitLength);

            return most * most.InvertBits(bitLength);
        }

        public static uint Task2(IEnumerable<uint> input, int bitLength)
        {
            return input.ToRating(bitLength) * input.ToRating(bitLength, true);
        }        
    }
    public static class Extensions
    {
        public static uint ToRating(this IEnumerable<uint> input, int bitLength, bool invert = false)
        {
            IEnumerable<uint> rating = input.ToList();

            for (var i = 1u << bitLength - 1; i >= 1; i >>= 1)
            {
                if (rating.Count() == 1) break;

                var flag = rating.GetCommonBit(i);
                var mask = invert ? flag.InvertBits(bitLength) & i : flag;

                rating = rating.Where(x => (x & i) == mask).ToList();
            }

            return rating.First();
        }

        public static uint GetCommonBit(this IEnumerable<uint> input, uint bit)
        {
            var agg = input.Aggregate(0, (count, n) => count + ((n & bit) == bit ? 1 : 0));

            return agg >= input.Count() / 2d ? bit : 0;
        }

        public static uint MostBits(this IEnumerable<uint> input, int bitLength)
        {
            uint count = 0;

            for (var i = 1u << bitLength - 1; i >= 1; i >>= 1)
            {
                count += input.GetCommonBit(i);
            }

            return count;
        }

        public static uint InvertBits(this uint input, int bitLength)
        {
            return (1u << bitLength) - input - 1;
        }
    }
}
