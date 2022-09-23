using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopLevelStatements
{
    internal static class Utilities
    {
        public static async Task ShowConsoleAnimation()
        {
            foreach (string s in new[] { "| -", "/ \\", "- |", "\\ /", })
            {
                Console.Write(s);
                await Task.Delay(50);
                Console.Write("\b\b\b");
            }
            Console.WriteLine();
        }
    }
}
