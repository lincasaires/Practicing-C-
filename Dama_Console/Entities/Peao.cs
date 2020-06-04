using Dama_Console.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    class Peao:Peca
    {

        public Peao(int linha, int coluna, Cor cor) : base(linha,coluna,cor) { }


        public override void MoverPeca(int linha, int coluna)
        {
            if (Tab.Casa[linha,coluna] != null)
            {
                Console.Write("Destino: ");
                string destino = Console.ReadLine();

            }
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
