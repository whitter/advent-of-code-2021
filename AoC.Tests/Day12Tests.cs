using AoC.Common;
using AoC.Day12;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Tests
{
    public class Day12Tests
    {
        private readonly ILookup<string, string> _paths = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW".SplitByNewline()
            .ToPaths();

        [Test]
        public void Task1_Result()
        {
            var result = Program.Task1(_paths);

            Assert.AreEqual(226, result);
        }

        [Test]
        public void Task2_Result()
        {
            var result = Program.Task2(_paths);

            Assert.AreEqual(3509, result);
        }
    }
}