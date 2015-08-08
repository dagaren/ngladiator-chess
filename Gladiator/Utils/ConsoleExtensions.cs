using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    public static class ConsoleExtensions
    {
        public static void WriteColoured(string text, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = previousColor;
        }

        public static void WriteLineColoured(string text, ConsoleColor color)
        {
            WriteColoured(text, color);
            Console.WriteLine();
        }
    }
}
