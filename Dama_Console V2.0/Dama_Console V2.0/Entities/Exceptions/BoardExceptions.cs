using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console_V2._0.Entities.Exceptions
{
    class BoardExceptions:SystemException
    {
        public BoardExceptions(string msg) : base(msg) { }
    }
}
