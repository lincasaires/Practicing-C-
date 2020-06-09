using Dama_Console_V2._0.Entities;
using Dama_Console_V2._0.Entities.Enums;
using Dama_Console_V2._0.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console_V2._0
{
    class DamaMatch
    {
        public Board Board { get; set; }
        public int Round { get; set; }
        public int WhiteScore { get; set; }
        public int BlackScore { get; set; }

        public DamaMatch()
        {
            Board = new Board(10, 10);
            Round = 0;
        }


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

            //PROCEDURES AFTER CHECK
            Board.PossibleMoves = Board.Pieces[origin.Line, origin.Column].PossibleMoves();
            Board.PrintBoard();
            return true;
        }

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
                destination = PieceEater(p, destination);
            }
            p.Position = destination;

            Board.Pieces[destination.Line, destination.Column] = p;
            Board.Pieces[origin.Line, origin.Column] = null;
            if (p.Ate_a_Piece)
                NewTargetCheck(p);


            //PROCEDURES AFTER A COMPLETE MOVE
            Round++;
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

        //AFTER EAT A PIECE, IF ANOTHER PIECE WAS FOUND, THE PLAYER CAN MOVE AGAIN
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
            Positions test = new Positions(4, 5);
            Board.Pieces[4, 5] = new King(Board, test, Colors.Black);
        }
    }
}
