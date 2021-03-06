using AoC.Common;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Day4
{
    public class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            var input = Load()
                .SplitByBlankLine();

            var balls = input[0].ToArray<int>();

            var cards = input[1..]
                .Select(Card.Parse)
                .ToArray();

            var winners = Winners(balls, cards);

            Console.WriteLine($"Task 1: {winners.First()}");
            Console.WriteLine($"Task 2: {winners.Last()}");
        }

        public static IEnumerable<int> Winners(int[] balls, Card[] cards)
        {
            List<int> winners = new List<int>();

            foreach (var ball in balls)
            {
                List<Card> remove = new List<Card>();

                foreach (var card in cards)
                {
                    if (card.Mark(ball))
                    {
                        winners.Add(card.SumUnmarked() * ball);

                        remove.Add(card);
                    }
                }

                cards = cards.Except(remove).ToArray();
            }

            return winners;
        }
    }

    public class Card
    {
        private Number[,] Numbers { get; set; }

        private Dictionary<int, Number> NumberDictionary { get; set; }

        public static Card Parse(string input)
        {
            var card = new Card
            {
                Numbers = input
                    .SplitByNewline()
                    .Select(r => r.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => new Number(Convert.ToInt32(n))).ToArray())
                    .ToArray()
                    .To2DArray()
            };

            card.NumberDictionary = card.Numbers
                .Flatten()
                .ToDictionary(x => x.Value);

            return card;
        }
    
        public bool Mark(int ball)
        {
            if(!NumberDictionary.ContainsKey(ball))
            {
                return false;
            }

            NumberDictionary[ball].Marked = true;

            return IsBingo();
        }

        private bool IsBingo()
        {
            bool row = Numbers
                .SliceRows()
                .Any(r => r.All(n => n.Marked));

            bool column = Numbers
                .SliceColumns()
                .Any(c => c.All(n => n.Marked));

            return row || column;
        }

        public int SumUnmarked()
        {
            return Numbers
                .Flatten()
                .Where(x => !x.Marked)
                .Sum(x => x.Value);
        }
    }

    public class Number
    {
        public int Value { get; set; }
        public bool Marked { get; set; }

        public Number(int value)
        {
            Value = value;
        }
    }

    public static class Extensions
    {        
        public static IEnumerable<T> Flatten<T>(this T[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    yield return array[row, column];
                }
            }
        }        
    }
}
