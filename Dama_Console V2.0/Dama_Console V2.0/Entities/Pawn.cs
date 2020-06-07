using System;
using System.Collections.Generic;
using System.Text;
using Dama_Console_V2._0.Entities.Enums;

namespace Dama_Console_V2._0.Entities
{
    class Pawn:Piece
    {
        public Pawn(Positions position, Colors color) : base(position, color) { }










       





        public override string ToString()
        {
            return "P ";
        }
    }
}
