using Checkers_Console_V2._0.Entities;
using Checkers_Console_V2._0.Entities.Exceptions;
using System;

namespace Checkers_Console_V2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckersMatch match = new CheckersMatch();
            match.BoardPawnsStarter();
            match.Board.PrintBoard();

            while (!match.Finished)
            {

                try
                {
                    
                    
                    Console.Write("Origin: ");
                    string s = Console.ReadLine();
                    Positions origin = new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
                    match.CheckOrigin(origin);

                    Console.Write("Destination: ");
                    s = Console.ReadLine();
                    Positions destination = new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
                    match.CheckDestination(destination);

                    match.MovePiece(origin, destination);
                    match.Round++;

                    Console.Clear();
                    match.Board.PrintBoard();
                    Console.WriteLine();

                    if (match.BlackScore >= 15)
                    {
                        match.Finished = true;
                        Console.WriteLine("Game Over. Black Pieces WINS!");
                    }
                    else if (match.WhiteScore >= 15)
                    {
                        match.Finished = true;
                        Console.WriteLine("Game Over. White Pieces WINS!");
                    }
                }
                catch (BoardExceptions e)
                {
                    Console.Clear();
                    match.Board.PrintBoard();
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.Clear();
                    match.Board.PrintBoard(); 
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
