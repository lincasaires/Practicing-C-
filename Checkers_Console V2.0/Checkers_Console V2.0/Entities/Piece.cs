using Checkers_Console_V2._0.Entities.Enums;
using System.Collections.Generic;

namespace Checkers_Console_V2._0.Entities
{
    abstract class Piece
    {
        public Colors Color { get; protected set; }
        public Positions Position { get; set; }
        public Board Board { get; protected set; }
        public bool TargetFound { get;  set; }
        public List<Piece> Target { get; set; }
        public bool Ate_a_Piece { get; set; }
        public Piece(Board board,Positions position, Colors color)
        {
            Position = position;
            Color = color;
            Board = board;
            TargetFound = false;
            Target = new List<Piece>();
            Ate_a_Piece = false;
        }

        public Piece(Colors color, Positions position)
        {
            Color = color;
            Position = position;
        }

        public abstract bool[,] PossibleMoves();

        
    }
}
