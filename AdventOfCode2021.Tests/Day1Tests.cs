using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2021.Tests
{
    public class Day1Tests
    {
        private readonly IEnumerable<int> _input = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Test]
        public void Task1()
        {
            var result = Day1.Task1.Process(_input);

            Assert.AreEqual(result, 7);
        }

        [Test]
        public void Task2()
        {
            var result = Day1.Task2.Process(_input);

            Assert.AreEqual(result, 5);
        }
    }
}