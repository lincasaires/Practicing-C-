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
        public bool[,] MovimentoPossivel { get; set; }

        public Tabuleiro() { }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            MovimentoPossivel = new bool[Linhas, Colunas];

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
                    if ((i == 0 || i == 2) && j % 2 == 0)
                        mat[i, j] = new Peao(i, j, Enums.Cor.Branca);
                    else if (i == 1 && j % 2 != 0)
                        mat[i, j] = new Peao(i, j, Enums.Cor.Branca);

                    //Inserindo peças pretas
                    if ((i == Linhas - 1 || i == Linhas - 3) && j % 2 != 0)
                        mat[i, j] = new Peao(i, j, Enums.Cor.Preta);
                    else if (i == Linhas - 2 && j % 2 == 0)
                        mat[i, j] = new Peao(i, j, Enums.Cor.Preta);
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
                    if (Casa[i, j] != null)
                    {
                        //Imprimindo peças pretas
                        if (Casa[i, j].Cor == Enums.Cor.Preta)
                        {
                            if (MovimentoPossivel[i, j] == false)
                            {
                                ConsoleColor aux = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(Casa[i, j] + " ");
                                Console.ForegroundColor = aux;
                            }
                            else
                            {
                                ConsoleColor auxBack = Console.BackgroundColor;
                                ConsoleColor auxFore = Console.ForegroundColor;
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(Casa[i, j] + " ");
                                Console.BackgroundColor = auxBack;
                                Console.ForegroundColor = auxFore;
                            }
                        }
                        //Imprimindo peças brancas
                        else
                        {
                            if (MovimentoPossivel[i,j] == false)
                                Console.Write(Casa[i, j] + " ");
                            else
                            {
                                ConsoleColor aux = Console.BackgroundColor;                                
                                Console.BackgroundColor = ConsoleColor.DarkGray;                                
                                Console.Write(Casa[i, j] + " ");
                                Console.BackgroundColor = aux;                               
                            }
                        }
                    }
                    //Pintando de branco as casas vazias com movimento possivel
                    else if (MovimentoPossivel[i, j] == true)
                    {
                        ConsoleColor aux = Console.BackgroundColor;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("- ");
                        Console.BackgroundColor = aux;
                        MovimentoPossivel[i, j] = false;
                    }
                    else
                        Console.Write("- ");

                    
                    
                }
                Console.WriteLine();
                
            }

            LimparMovimentosPossiveis();

            Console.Write("  ");
            for (int i = 0; i < Colunas; i++)
                Console.Write(i + " ");
            Console.WriteLine();
        }
        public void LimparMovimentosPossiveis()
        {
            for (int i = 0; i < Linhas; i++)
                for (int j = 0; j < Colunas; j++)
                {
                    MovimentoPossivel[i, j] = false;
                }
        }
    }
}
