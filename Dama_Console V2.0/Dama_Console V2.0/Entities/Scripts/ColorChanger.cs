using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Dama_Console_V2._0.Entities.Scripts
{
    class ColorChanger
    {
        public static void WhiteBackground(string s)
        {

        }

        public static void YellowForegroundColor(string s)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ForegroundColor = aux;
        }
    }
}
