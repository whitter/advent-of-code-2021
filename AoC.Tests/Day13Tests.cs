using AoC.Common;
using AoC.Day13;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day13Tests
    {
        private readonly ((int, int)[], (string, int)[]) _input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5".ToMapAndFolds();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_input);

            Assert.AreEqual(17, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(3509, result);
        }
    }
}