using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LibExcercise
{
    public class Other
    {

        public static void Warning(string text) 
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("---------------------------");
            WriteLine($"{text}");
            WriteLine("---------------------------");
            ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(2000);
        }

        public static void Text(string text)
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("---------------------------");
            WriteLine($"{text}");
            WriteLine("---------------------------");
            ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(1000);
        }

    }
}
