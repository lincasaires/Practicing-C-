using Checkers_Console_V2._0.Entities;
using Checkers_Console_V2._0.Entities.Enums;
using Checkers_Console_V2._0.Entities.Exceptions;
using System;
using System.Collections.Generic;


namespace Checkers_Console_V2._0
{
    class CheckersMatch
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public int WhiteScore { get; private set; }
        public int BlackScore { get; private set; }

        public bool Finished { get; private set; }

        public CheckersMatch()
        {
            Board = new Board(10, 10);
            Round = 0;
            Finished = false;
        }

        public void AddRound()
        {
            Round++;
        }

        public void FinishMatch()
        {
            Finished = true;
        }

        //INITIALIZE PAWNS INTO THE INITIAL BOARD
        public void BoardPawnsStarter()
        {
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    Positions pos = new Positions(i, j);

                    if (i % 2 != j % 2)
                    {
                        //Starting white pawns
                        if (i <= 2)
                        {
                            Board.Pieces[i, j] = new Pawn(Board, pos, Colors.White);
                        }

                        //Starting black pawns
                        if (i >= (Board.Lines - 3))
                        {
                            Board.Pieces[i, j] = new Pawn(Board, pos, Colors.Black);
                        }
                    }
                }
            }
        }

        //IF ROUND IS INT PAIR, BLACK PLAYS, ELSE, WHITE PLAYS
        public void PrintWhoPlaysNow()
        {
            Console.WriteLine();
            Console.Write("Player: ");
            if (Round % 2 == 0)
            {
                Console.WriteLine("Black");
            }
            else if (Round % 2 == 1)
            {
                Console.WriteLine("White");
            }
        }

        //CHECK ORIGIN POSITION
        public bool CheckOrigin(Positions origin)
        {
            Piece p = Board.Pieces[origin.Line, origin.Column];

            //CHECK PIECE EXISTENCE
            if (p == null)
            {
                Board.PossibleMoves = new bool[Board.Lines, Board.Columns];
                throw new BoardExceptions("No pieces in this position!");
            }

            //CHECK TURN
            if (p.Color == Colors.Black && Round % 2 != 0)//Pair Round = Black turn
                throw new BoardExceptions("Wrong piece, it's White round");
            else if (p.Color == Colors.White && Round % 2 != 1)//Odd Round = White turn
                throw new BoardExceptions("Wrong piece, it's Black round");

            //PROCEDURES AFTER CHECK ORIGIN
            Board.PossibleMoves = p.PossibleMoves();
            Board.PrintBoard();
            return true;
        }

        
        //CHECK DESTINATION POSITION, IF IT'S == POSSIBLE MOVES POSITION, RETURN TRUE
        public bool CheckDestination(Positions destination)
        {
            if (!Board.PossibleMoves[destination.Line, destination.Column])
            {
                Board.PossibleMoves = new bool[Board.Lines, Board.Columns];
                throw new BoardExceptions("You cannot move to that position");
            }

            return true;
        }

        public void MovePiece(Positions origin, Positions destination)
        {
            //REALIZE THE MOVE
            Piece p = Board.TakePieceOff(origin);//If there's a piece in this position(origin), return the piece from origin to p

            
            if (p.TargetFound)
            {
                destination = PieceEater(p, destination);//If target was found and eaten, p.Ate_a_Piece = true
            }
            p.Position = destination;

            Board.Pieces[destination.Line, destination.Column] = p;
            Board.Pieces[origin.Line, origin.Column] = null;

            if (p.Ate_a_Piece)//After ate a piece, check if there's another piece available to eat
                NewTargetCheck(p);


            //PROCEDURES AFTER A COMPLETE MOVE
            p.Ate_a_Piece = false;
            AddKing(p);//Checks if the piece is in the position to become king
            Board.PossibleMoves = new bool[Board.Lines, Board.Columns];
        }

        public void AddKing(Piece p)
        {
            if (p.Color == Colors.Black && p.Position.Line == 0)
            {
                Board.Pieces[p.Position.Line, p.Position.Column] = new King(Board, p.Position, p.Color);
            }
            else if (p.Color == Colors.White && p.Position.Line == Board.Lines - 1)
            {
                Board.Pieces[p.Position.Line, p.Position.Column] = new King(Board, p.Position, p.Color);
            }
        }

        //AFTER EAT A PIECE, IF ANOTHER VULNERABLE PIECE WAS FOUND, THE PLAYER CAN EAT THIS
        public void NewTargetCheck(Piece p)
        {
            p.Target = new List<Piece>();
            Board.PossibleMoves = new bool[Board.Lines, Board.Columns];
            Board.PossibleMoves = p.PossibleMoves();

            if (p.TargetFound)
            {
                Board.PossibleMoves = new bool[Board.Lines, Board.Columns];
                foreach (Piece t in p.Target)
                {
                    Board.PossibleMoves[t.Position.Line, t.Position.Column] = true;
                }

                bool repeat = true;
                while (repeat)
                {
                    repeat = false;
                    try
                    {
                        Board.PrintBoard();
                        Console.WriteLine("New target found, choose new destination:");
                        Console.Write("Destination: ");
                        string s = Console.ReadLine();
                        Positions destination = new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
                        if (NewTargetDestinationCheck(destination))
                        {
                            MovePiece(p.Position, destination);
                            p.TargetFound = false;
                        }
                        else
                            NewTargetCheck(p);
                    }
                    catch (Exception)
                    {
                        repeat = true;
                    }
                }
            }
        }

        public bool NewTargetDestinationCheck(Positions destination)
        {
            if (!Board.PossibleMoves[destination.Line, destination.Column])
                return false;
            return true;
        }
        public void ScoreCounter(Piece p)
        {
            if (p.Color == Colors.White)
            {
                WhiteScore++;
            }
            else
                BlackScore++;
        }

        public Positions PieceEater(Piece p, Positions destination)
        {
            foreach (Piece t in p.Target)
            {

                //EAT TARGET FROM RIGHT UP
                if (t.Position.Line == p.Position.Line - 1 && t.Position.Column == p.Position.Column + 1)
                {
                    if (destination.Line == t.Position.Line && destination.Column == t.Position.Column)
                    {
                        destination = new Positions(p.Position.Line - 2, p.Position.Column + 2);
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                    else if (destination.Line == t.Position.Line - 1 && destination.Column == t.Position.Column + 1)
                    {
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                }

                //EAT TARGET FROM LEFT UP
                if (t.Position.Line == p.Position.Line - 1 && t.Position.Column == p.Position.Column - 1)
                {
                    if (destination.Line == t.Position.Line && destination.Column == t.Position.Column)
                    {
                        destination = new Positions(p.Position.Line - 2, p.Position.Column - 2);
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                    else if (destination.Line == t.Position.Line - 1 && destination.Column == t.Position.Column - 1)
                    {
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                }

                //EAT TARGET FROM LEFT DOWN
                if (t.Position.Line == p.Position.Line + 1 && t.Position.Column == p.Position.Column - 1)
                {
                    if (destination.Line == t.Position.Line && destination.Column == t.Position.Column)
                    {
                        destination = new Positions(p.Position.Line + 2, p.Position.Column - 2);
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                    else if (destination.Line == t.Position.Line + 1 && destination.Column == t.Position.Column - 1)
                    {
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                }

                //EAT TARGET FROM RIGHT DOWN
                if (t.Position.Line == p.Position.Line + 1 && t.Position.Column == p.Position.Column + 1)
                {
                    if (destination.Line == t.Position.Line && destination.Column == t.Position.Column)
                    {
                        destination = new Positions(p.Position.Line + 2, p.Position.Column + 2);
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                    else if (destination.Line == t.Position.Line + 1 && destination.Column == t.Position.Column + 1)
                    {
                        Board.Pieces[t.Position.Line, t.Position.Column] = null;
                        p.Ate_a_Piece = true;
                        ScoreCounter(p);
                        p.TargetFound = false;
                    }
                }
            }

            return destination;
        }
    }
}
