using AoC.Common;
using AoC.Day11;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day11Tests
    {
        private readonly int[,] _lines = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526".SplitByNewline()
            .Select(x => x.Select(c => c - '0').ToArray())
            .ToArray()
            .To2DArray();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_lines);

            Assert.AreEqual(1656, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_lines);

            Assert.AreEqual(195, result);
        }
    }
}