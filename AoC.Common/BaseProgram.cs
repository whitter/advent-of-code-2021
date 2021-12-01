using System;
using System.Collections.Generic;
using System.IO;

namespace AoC.Common
{
    public abstract class BaseProgram
    {
        protected static IEnumerable<string> Load()
        {
            string content;

            using (var reader = new StreamReader("input.txt"))
            {
                content = reader.ReadToEnd();
            }

            return content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
