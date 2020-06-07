using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console_V2._0.Entities
{
    class Positions
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Positions(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
