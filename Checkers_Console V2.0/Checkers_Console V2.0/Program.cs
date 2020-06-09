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

                    match.PrintWhoPlaysNow();
                    Console.Write("Origin: ");
                    Positions origin = Positions.ReadString_ReturnPosition(Console.ReadLine());
                    match.CheckOrigin(origin);

                    match.PrintWhoPlaysNow();
                    Console.Write("Destination: ");
                    Positions destination = Positions.ReadString_ReturnPosition(Console.ReadLine());
                    match.CheckDestination(destination);

                    match.MovePiece(origin, destination);
                    match.AddRound();

                    
                    match.Board.PrintBoard();
                    

                    if (match.BlackScore >= 15)
                    {
                        match.FinishMatch();
                        Console.WriteLine("Game Over. Black Pieces WINS!");
                    }
                    else if (match.WhiteScore >= 15)
                    {
                        match.FinishMatch();
                        Console.WriteLine("Game Over. White Pieces WINS!");
                    }
                }
                catch (BoardExceptions e)
                {
                    match.Board.RestartBoard();
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    match.Board.RestartBoard();
                    Console.WriteLine(e.Message + " Try only numbers like 12 for (Line 1, Column 2)!");
                }
                catch (Exception e)
                {
                    match.Board.RestartBoard();
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
