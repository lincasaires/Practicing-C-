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
        public int Rotation { get; set; }

        public DamaMatch()
        {
            Board = new Board(10, 10);
            Rotation = 0;
        }




        public void MovePiece(Positions origin, Positions destination)
        {
            if (Board.TakePieceOff(origin) == null)
                throw new BoardExceptions("No pieces in this position!");

            Piece p = Board.TakePieceOff(origin);


            p.Position = destination;
            Board.Pieces[destination.Line, destination.Column] = p;


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
        }
    }
}
