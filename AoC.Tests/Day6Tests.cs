using AoC.Day6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day6Tests
    {
        private readonly long[] _days = new int[] { 3, 4, 3, 1, 2 }.ToDays();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_days);

            Assert.AreEqual(5934, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_days);

            Assert.AreEqual(26984457539, result);
        }
    }
}