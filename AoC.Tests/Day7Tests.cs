using AoC.Day7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day7Tests
    {
        private readonly double[] _crabs = new double[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_crabs);

            Assert.AreEqual(37, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_crabs);

            Assert.AreEqual(168, result);
        }
    }
}