using Dama_Console.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    abstract class Peca
    {
        public Cor Cor { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Tabuleiro Tab { get; set; }


        public Peca() { }

        public Peca(Cor cor)
        {
            Cor = cor;
        }
        public Peca(int linha, int coluna, Cor cor)
        {
            Linha = linha;
            Coluna = coluna;
            Cor = cor;
        }

        public abstract void MoverPeca(int linha,int coluna);


    }
}
