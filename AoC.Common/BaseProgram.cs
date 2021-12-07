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

        public static T[] ToArray<T>(this string value)
        {
            return value
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }
    }
}
