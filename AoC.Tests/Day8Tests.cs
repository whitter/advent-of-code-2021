using AoC.Day8;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day8Tests
    {
        private readonly (int, int)[] _displays = new (int, int)[]
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe".ToDigits(),
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc".ToDigits(),
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg".ToDigits(),
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb".ToDigits(),
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea".ToDigits(),
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb".ToDigits(),
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe".ToDigits(),
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef".ToDigits(),
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb".ToDigits(),
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce".ToDigits()
        };

        [Test]
        public void Task1_Result()
        {
            var result = _displays.Sum(x => x.Item1);

            Assert.AreEqual(26, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = _displays.Sum(x => x.Item2);

            Assert.AreEqual(61229, result);
        }
    }
}