using AoC.Common;
using AoC.Day15;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day15Tests
    {
        private readonly string _input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_input);

            Assert.AreEqual(40, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(315, result);
        }
    }
}