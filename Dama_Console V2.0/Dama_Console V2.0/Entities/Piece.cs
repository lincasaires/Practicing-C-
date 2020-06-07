using Dama_Console_V2._0.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Dama_Console_V2._0.Entities
{
    class Piece
    {
        public Colors Color { get; set; }
        public Positions Position { get; set; }
        public Board Board { get; set; }
        public Piece(Positions position, Colors color)
        {
            Position = position;
            Color = color;
        }

        
    }
}
