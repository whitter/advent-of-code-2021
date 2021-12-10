using AoC.Common;
using AoC.Day9;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day9Tests
    {
        private readonly int[,] _caves = @"2199943210
3987894921
9856789892
8767896789
9899965678".SplitByNewline()
            .Select(x => x.Select(c => c - '0').ToArray())
            .ToArray()
            .To2DArray();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_caves);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_caves);

            Assert.AreEqual(1134, result);
        }
    }
}