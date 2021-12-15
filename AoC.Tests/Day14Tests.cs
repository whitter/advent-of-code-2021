using AoC.Common;
using AoC.Day14;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day14Tests
    {
        private const string _template = "NNCB";

        private readonly Dictionary<string, (string, long)> _pairs = @"CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".ToPairs(_template);

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_pairs, _template);

            Assert.AreEqual(1588, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_pairs, _template);

            Assert.AreEqual(2188189693529, result);
        }
    }
}