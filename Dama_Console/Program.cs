using Dama_Console.Entities;
using System;

namespace Dama_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(10,10);

            tab.ImprimirTabuleiro();
            
        }
    }
}
