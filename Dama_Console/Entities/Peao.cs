using Dama_Console.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    class Peao:Peca
    {

        public Peao(int linha, int coluna, Cor cor) : base(linha,coluna,cor) { }
        public Peao() { }


        

        public override string ToString()
        {
            return "P";
        }
    }
}
