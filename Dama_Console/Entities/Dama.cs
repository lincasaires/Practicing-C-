using Dama_Console.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    class Dama:Peca
    {
        public Dama(int linha,int coluna,Cor cor) : base(linha, coluna, cor) { }

        public override string ToString()
        {
            return "D";
        }
    }
}
