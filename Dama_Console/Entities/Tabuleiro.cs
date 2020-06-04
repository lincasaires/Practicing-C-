using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console.Entities
{
    class Tabuleiro
    {
        public Peca[,] Casa { get; set; }
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Tabuleiro() { }

        public Tabuleiro(int linhas,int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;

            Casa = CriarTabuleiro();
        }

        public Peca[,] CriarTabuleiro()
        {
            Peca[,] mat = new Peca[Linhas, Colunas];
            for (int i = 0; i < Linhas; i++)
            {
                for (int j = 0; j < Colunas; j++)
                {
                    //Inserindo peças brancas
                    if ((i == 0 || i==2) && j%2 ==0)
                        mat[i, j] = new Peao(i,j,Enums.Cor.Branca);
                    else if (i == 1 && j % 2 != 0)
                        mat[i, j] = new Peao(i,j,Enums.Cor.Branca);

                    //Inserindo peças pretas
                    if ((i == Linhas-1 || i == Linhas-3) && j % 2 != 0)
                        mat[i, j] = new Peao(i,j,Enums.Cor.Preta);
                    else if (i == Linhas-2 && j % 2 == 0)
                        mat[i, j] = new Peao(i,j,Enums.Cor.Preta);
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
                    if(Casa[i,j] != null)
                    {
                        //Imprimindo peças pretas
                        if (Casa[i,j].Cor == Enums.Cor.Preta)
                        {
                            ConsoleColor aux = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(Casa[i, j] + " ");
                            Console.ForegroundColor = aux;
                        }
                        //Imprimindo peças brancas
                        else
                            Console.Write(Casa[i, j] + " ");
                    }                        
                    else
                        Console.Write("- ");

                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < Linhas; i++)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        
    }
}
