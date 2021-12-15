using AoC.Common;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Day10
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByNewline()
                .Scores();

            Console.WriteLine($"Task 1: {Task1(input)}");
            Console.WriteLine($"Task 2: {Task2(input)}");
        }

        public static double Task1(IEnumerable<(State state, double score)> input)
        {
            return input
                .Where(x => x.state == State.Corrupted)
                .Sum(x => x.score);
        }

        public static double Task2(IEnumerable<(State state, double score)> input)
        {
            return input
                .Where(x => x.state == State.Incomplete)
                .Select(x => x.score)
                .Median();
        }
    }    

    public enum State
    {
        Corrupted,
        Incomplete
    }

    public static class Extensions
    {
        private static readonly Dictionary<char, (char open, int score)> corrupted = new()
        {
            { ')', ('(', 3) },
            { ']', ('[', 57) },
            { '}', ('{', 1197) },
            { '>', ('<', 25137) }
        };

        private static readonly Dictionary<char, int> incomplete = new()
        {
            { '(', 1 },
            { '[', 2 },
            { '{', 3 },
            { '<', 4 }
        };

        public static IEnumerable<(State, double)> Scores(this string[] input)
        {
            foreach(var line in input)
            {
                yield return line.Score();
            }

            yield break;
        }

        public static (State, double) Score(this string line)
        {
            var stack = new Stack<char>();

            foreach (var c in line)
            {
                switch (c)
                {
                    case '(':
                    case '[':
                    case '<':
                    case '{':
                        stack.Push(c);
                        continue;                        
                }

                if (stack.Peek() == corrupted[c].open)
                {
                    stack.Pop();
                }
                else
                {
                    return (State.Corrupted, corrupted[c].score);
                }
            }

            var score = 0d;

            while (stack.TryPop(out char c))
            {
                score = score * 5 + incomplete[c];
            }

            return (State.Incomplete, score);
        }
    }
}
