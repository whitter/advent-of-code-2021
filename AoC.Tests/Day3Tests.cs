using AoC.Day3;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class Day3Tests
    {
        private readonly IEnumerable<uint> _input = new uint[] { 
            Convert.ToUInt32("00100", 2),
            Convert.ToUInt32("11110", 2),
            Convert.ToUInt32("10110", 2),
            Convert.ToUInt32("10111", 2),
            Convert.ToUInt32("10101", 2),
            Convert.ToUInt32("01111", 2),
            Convert.ToUInt32("00111", 2),
            Convert.ToUInt32("11100", 2),
            Convert.ToUInt32("10000", 2),
            Convert.ToUInt32("11001", 2),
            Convert.ToUInt32("00010", 2),
            Convert.ToUInt32("01010", 2)
        };

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_input, 5);

            Assert.AreEqual(198, result);
        }

        [Test]
        public void Task1_Most()
        {
            var result = _input.MostBits(5);

            Assert.AreEqual(Convert.ToInt32("10110", 2), result);
        }

        [Test]
        public void Task1_Least()
        {
            var most = _input.MostBits(5);
            var result = most.InvertBits(5);

            Assert.AreEqual(Convert.ToInt32("01001", 2), result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_input, 5);

            Assert.AreEqual(230, result);
        }

        [Test]
        public void Task2_O2()
        {
            var result = _input.ToRating(5, false);

            Assert.AreEqual(Convert.ToInt32("10111", 2), result);
        }

        [Test]
        public void Task2_CO2()
        {
            var result = _input.ToRating(5, true);

            Assert.AreEqual(Convert.ToInt32("01010", 2), result);
        }
    }
}