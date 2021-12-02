using AoC.Day1;
using NUnit.Framework;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class Day1Tests
    {
        private readonly IEnumerable<int> _input = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_input);

            Assert.AreEqual(result, 7);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_input);

            Assert.AreEqual(result, 5);
        }
    }
}