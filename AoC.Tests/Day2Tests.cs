using AoC.Day2;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class Day2Tests
    {
        private readonly IEnumerable<int> _input = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Test]
        public void Task1()
        {
            var result = Program.Task1(_input);

            Assert.AreEqual(result, 7);
        }

        [Test]
        public void Task2()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(result, 5);
        }
    }
}