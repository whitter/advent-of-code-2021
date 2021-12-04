using AoC.Day4;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day4Tests
    {
        private readonly int[] _balls = new int[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
        private readonly Card[] _cards = new Card[] {
            Card.Parse(@"22 13 17 11  0
             8  2 23  4 24
            21  9 14 16  7
             6 10  3 18  5
             1 12 20 15 19"),

            Card.Parse(@" 3 15  0  2 22
             9 18 13 17  5
            19  8  7 25 23
            20 11 10 24  4
            14 21 16 12  6"),

            Card.Parse(@"14 21 17 24  4
            10 16 15  9 19
            18  8 23 26 20
            22 11 13  6  5
             2  0 12  3  7")
        };

        private IEnumerable<int> Winners { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Winners = Program.Winners(_balls, _cards);
        }

        [Test]
        public void Task1_Result()
        {
            var result = Winners.First();

            Assert.AreEqual(4512, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Winners.Last();

            Assert.AreEqual(1924, result);
        }
    }
}