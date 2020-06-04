using Dama_Console.Entities;
using Dama_Console.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console
{
    class Partida
    {
        public int Turno { get; private set; }
        public int CemiterioBrancas { get; private set; }
        public int CemiterioPretas { get; private set; }
        public Tabuleiro Tab { get; private set; }
        public bool Terminada { get; private set; }

        public Partida()
        {
            Turno = 0;
            Tab = new Tabuleiro(10, 10);
            CemiterioBrancas = 0;
            CemiterioPretas = 0;
            Terminada = false;
        }


        public void Menu()
        {
            Console.WriteLine();
            Tab.ImprimirTabuleiro();

            Console.WriteLine("Turno: " + Turno);
            Console.Write("Jogador: ");
            if (Turno %2 == 0)
                Console.Write("Preto");
            else
                Console.Write("Branco");
            Console.WriteLine();
            Console.Write("Origem: ");
            string s = Console.ReadLine();
            int linhaOrigem = int.Parse(s[0] + "");
            int colunaOrigem = int.Parse(s[1] + "");

            Peca origem = Tab.Casa[linhaOrigem, colunaOrigem];
            ValidarOrigem(origem);

            MoverPeca(linhaOrigem, colunaOrigem);
        }

        public void ValidarOrigem(Peca origem)
        {
            if (origem == null)
            {
                Console.Clear();
                throw new PartidaException("Não há peças neste ponto!");
            }
            if ((origem.Cor == Entities.Enums.Cor.Branca && Turno % 2 == 0) || (origem.Cor == Entities.Enums.Cor.Preta && Turno % 2 != 0))
            {
                Console.Clear();
                throw new PartidaException("Peça incorreta!");
            }
        }
        public void MoverPeca(int linha, int coluna)
        {
            if (Tab.Casa[linha, coluna] != null)
            {
                Peca origem = Tab.Casa[linha, coluna];
                
                Console.Write("Destino: ");
                string s = Console.ReadLine();
                int linhaDestino = int.Parse(s[0] + "");
                int colunaDestino = int.Parse(s[1] + "");
                if (ValidarDestino(linhaDestino, colunaDestino, origem))
                {
                    Tab.Casa[linha, coluna] = null;
                    origem.Linha = linhaDestino;
                    origem.Coluna = colunaDestino;
                    Tab.Casa[linhaDestino, colunaDestino] = origem;
                    Console.Clear();
                    
                    Turno++;
                }
                else
                {
                    Console.Clear();
                    throw new PartidaException("Movimento inválido");
                }
                    
            }
        }

        public bool ValidarDestino(int linhaDestino, int colunaDestino, Peca origem)
        {
            Peca destino = Tab.Casa[linhaDestino, colunaDestino];

            //Trecho comum para validação de qualquer tipo de peça
            if (linhaDestino % 2 != origem.Linha % 2 && colunaDestino % 2 != origem.Coluna % 2 && (destino == null || destino.Cor != origem.Cor))
                if (colunaDestino - 1 == origem.Coluna || colunaDestino + 1 == origem.Coluna)
                {
                    //Validando peões
                    if (origem is Peao)
                    {
                        //Validando movimento do peão preto
                        if (origem.Cor == Entities.Enums.Cor.Preta && Turno %2==0)
                        {
                            if (linhaDestino < origem.Linha && linhaDestino == origem.Linha - 1)
                                return true;
                        }
                        //Validando movimento do peão branco
                        else if (origem.Cor == Entities.Enums.Cor.Branca && Turno %2 == 1)
                        {
                            if (linhaDestino > origem.Linha && linhaDestino == origem.Linha + 1)
                                return true;
                        }
                    }
                }
            return false;
        }

    }
}
