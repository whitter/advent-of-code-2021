using System;
using System.Collections.Generic;
using System.IO;

namespace AoC.Common
{
    public abstract class BaseProgram
    {
        protected static IEnumerable<string> Load()
        {
            return File.ReadAllLines("input.txt");
        }
    }
}
