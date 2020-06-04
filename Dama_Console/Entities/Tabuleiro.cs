using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    class Tabuleiro
    {
        public char[,] Casa { get; set; }
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Tabuleiro() { }

        public Tabuleiro(int linhas,int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;

            Casa = CriarTabuleiro();
        }

        public char[,] CriarTabuleiro()
        {
            char[,] mat = new char[Linhas, Colunas];
            for (int i = 0; i < Linhas; i++)
            {
                for (int j = 0; j < Colunas; j++)
                {
                    mat[i, j] = '-';
                }
            }
            return mat;
        }

        public void ImprimirTabuleiro()
        {           
            for (int i = 0; i < Linhas; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < Colunas; j++)
                {
                    Console.Write(Casa[i, j] + " "); ;
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < Linhas; i++)
                Console.Write(i + " ");

        }
    }
}
