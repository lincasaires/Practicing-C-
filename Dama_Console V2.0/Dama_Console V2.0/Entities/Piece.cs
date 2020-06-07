using Dama_Console_V2._0.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Dama_Console_V2._0.Entities
{
    abstract class Piece
    {
        public Colors Color { get; set; }
        public Positions Position { get; set; }
        public Board Board { get; set; }
        public Piece(Board board,Positions position, Colors color)
        {
            Position = position;
            Color = color;
            Board = board;
        }

        public Piece(Colors color, Positions position)
        {
            Color = color;
            Position = position;
        }

        public abstract bool[,] PossibleMoves();

        
    }
}
