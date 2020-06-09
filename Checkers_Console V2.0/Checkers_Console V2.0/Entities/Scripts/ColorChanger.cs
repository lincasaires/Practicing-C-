using System;


namespace Checkers_Console_V2._0.Entities.Scripts
{
    class ColorChanger
    {
        public static void WhiteBackground(string s)
        {
            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(s);
            Console.BackgroundColor = aux;
        }

        public static void Background(string s)
        {
            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(s);
            Console.BackgroundColor = aux;
        }

        public static void ForegroundColor(string s)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(s);
            Console.ForegroundColor = aux;
        }

        public static void BackgroundAndForegroundColor(string s)
        {
            ConsoleColor auxFore = Console.ForegroundColor;
            ConsoleColor auxBack = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(s);
            Console.ForegroundColor = auxFore;
            Console.BackgroundColor = auxBack;
        }

        public static void BoardBackground(string s)
        {
            ConsoleColor aux = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            
            Console.Write(s);
            Console.BackgroundColor = aux;
        }

        public static void BoardBackgroundAndForegroundColor(string s)
        {
            ConsoleColor auxFore = Console.ForegroundColor;
            ConsoleColor auxBack = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            
            Console.Write(s);
            Console.ForegroundColor = auxFore;
            Console.BackgroundColor = auxBack;
        }
    }
}
