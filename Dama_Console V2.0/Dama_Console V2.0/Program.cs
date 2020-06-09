﻿using Dama_Console_V2._0.Entities;
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

            while (true)
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
                    Console.Clear();
                    match.Board.PrintBoard();
                    Console.WriteLine(match.BlackScore);
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
