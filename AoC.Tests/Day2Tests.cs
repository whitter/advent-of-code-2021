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

            Assert.AreEqual(result, 150);
        }

        [Test]
        public void Task1_X()
        {
            (int x, _, _) = Program.CalcPosition(_input);

            Assert.AreEqual(x, 15);
        }

        [Test]
        public void Task1_D()
        {
            (_, _, int d) = Program.CalcPosition(_input);

            Assert.AreEqual(d, 10);
        }

        [Test]
        public void Task2()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(result, 900);
        }

        [Test]
        public void Task2_Y()
        {
            (_, int y, _) = Program.CalcPosition(_input);

            Assert.AreEqual(y, 60);
        }
    }
}