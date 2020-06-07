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
            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(s);
            Console.BackgroundColor = aux;
        }

        public static void GrayBackground(string s)
        {
            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(s);
            Console.BackgroundColor = aux;
        }

        public static void YellowForegroundColor(string s)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ForegroundColor = aux;
        }

        public static void BackgroundAndForegroundColor(string s)
        {
            ConsoleColor auxFore = Console.ForegroundColor;
            ConsoleColor auxBack = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write(s);
            Console.ForegroundColor = auxFore;
            Console.BackgroundColor = auxBack;
        }
    }
}
