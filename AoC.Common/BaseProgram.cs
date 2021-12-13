using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Common
{
    public abstract class BaseProgram
    {
        protected static string Load()
        {
            return File.ReadAllText("input.txt");
        }        
    }

    public static class Extensions
    {
        public static string[] SplitByNewline(this string input)
        {
            return input
                .Split(new[] { "\r", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        public static string[] SplitByBlankLine(this string input)
        {
            return input
                .Split(new[] { "\r\r", "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        public static T[] ToArray<T>(this string value, char separator = ',')
        {
            return value
                .Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }

        public static T[,] To2DArray<T>(this T[][] array)
        {
            int row = array.Length;

            int column = array
                .GroupBy(row => row.Length)
                .Single()
                .Key;

            var result = new T[row, column];

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    result[r, c] = array[r][c];
                }
            }

            return result;
        }

        public static IEnumerable<(int, int)> Neighbours<T>(this T[,] array, int x, int y)
        {
            var deltas = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            foreach ((int dy, int dx) in deltas)
            {
                if ((y + dy < 0 || y + dy > array.GetLength(0) - 1) || (x + dx < 0 || x + dx > array.GetLength(1) - 1))
                {
                    continue;
                }

                yield return (x + dx, y + dy);
            }

            yield break;
        }

        public static IEnumerable<(int, int)> Adjacents<T>(this T[,] array, int x, int y)
        {
            var deltas = new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

            foreach ((int dy, int dx) in deltas)
            {
                if ((y + dy < 0 || y + dy > array.GetLength(0) - 1) || (x + dx < 0 || x + dx > array.GetLength(1) - 1))
                {
                    continue;
                }

                yield return (x + dx, y + dy);
            }

            yield break;
        }

        public static IEnumerable<IEnumerable<T>> SliceRows<T>(this T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                yield return array.SliceRow(i);
            }
        }

        public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                yield return array[row, i];
            }
        }

        public static IEnumerable<IEnumerable<T>> SliceColumns<T>(this T[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                yield return array.SliceColumn(i);
            }
        }

        public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                yield return array[i, column];
            }
        }
    }
}
