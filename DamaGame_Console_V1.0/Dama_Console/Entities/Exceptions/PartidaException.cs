using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities.Exceptions
{
    class PartidaException : ApplicationException
    {
        public PartidaException(string msg) : base(msg) { }
    }
}
