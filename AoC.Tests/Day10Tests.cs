using AoC.Common;
using AoC.Day10;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day10Tests
    {
        private readonly IEnumerable<(State state, double score)> _lines = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".SplitByNewline().Scores();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_lines);

            Assert.AreEqual(26397d, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_lines);

            Assert.AreEqual(288957d, result);
        }
    }
}