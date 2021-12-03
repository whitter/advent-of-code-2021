using AoC.Day2;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class Day2Tests
    {
        private readonly IEnumerable<(string, int)> _input = new (string, int)[] { ("forward", 5), ("down", 5), ("forward", 8), ("up", 3), ("down", 8), ("forward", 2) };

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_input);

            Assert.AreEqual(150, result);
        }

        [Test]
        public void Task1_X()
        {
            (int x, _, _) = Program.CalcPosition(_input);

            Assert.AreEqual(15, x);
        }

        [Test]
        public void Task1_D()
        {
            (_, _, int d) = Program.CalcPosition(_input);

            Assert.AreEqual(10, d);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(900, result);
        }

        [Test]
        public void Task2_Y()
        {
            (_, int y, _) = Program.CalcPosition(_input);

            Assert.AreEqual(60, y);
        }
    }
}