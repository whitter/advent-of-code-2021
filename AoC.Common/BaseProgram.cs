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

        public static T[] ToArray<T>(this string value, char? separator = ',')
        {
            if(separator == null)
            {
                return value
                    .Select(x => (T)Convert.ChangeType(x.ToString(), typeof(T)))
                    .ToArray();
            }

            return value
                .Split(new char[] { separator.Value }, StringSplitOptions.RemoveEmptyEntries)
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
    }
}
