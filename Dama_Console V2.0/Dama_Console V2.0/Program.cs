using Dama_Console_V2._0.Entities;
using Dama_Console_V2._0.Entities.Exceptions;
using System;

namespace Dama_Console_V2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            DamaMatch match = new DamaMatch();
            match.BoardPawnsStarter();
            match.Board.PrintBoard();
            Console.WriteLine("Origin: ");
            string s = Console.ReadLine();
            Positions origin = new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
            if (match.Board.Pieces[origin.Line,origin.Column] == null)
                throw new BoardExceptions("No pieces in this position!");
            Console.Write("Destination: ");
            s = Console.ReadLine();
            Positions destination = new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
            match.MovePiece(origin, destination);
            Console.Clear();
            match.Board.PrintBoard();
        }
    }
}
