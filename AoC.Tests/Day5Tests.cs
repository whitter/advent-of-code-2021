using AoC.Day5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day5Tests
    {
        private readonly IEnumerable<Line> _lines = new List<Line>
        {
            Line.Parse("0,9 -> 5,9"),
            Line.Parse("8,0 -> 0,8"),
            Line.Parse("9,4 -> 3,4"),
            Line.Parse("2,2 -> 2,1"),
            Line.Parse("7,0 -> 7,4"),
            Line.Parse("6,4 -> 2,0"),
            Line.Parse("0,9 -> 2,9"),
            Line.Parse("3,4 -> 1,4"),
            Line.Parse("0,0 -> 8,8"),
            Line.Parse("5,5 -> 8,2")
        };

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_lines);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_lines);

            Assert.AreEqual(12, result);
        }
    }
}