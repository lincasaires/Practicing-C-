using Dama_Console_V2._0.Entities;
using System;

namespace Dama_Console_V2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10, 10);
            board.BoardPawnsStarter();
            board.PrintBoard();
        }
    }
}
