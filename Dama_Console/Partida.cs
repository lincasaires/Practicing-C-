using Dama_Console.Entities;
using Dama_Console.Entities.Enums;
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
        public bool Terminada { get;   set; }

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

            InfoMenu();
            Console.Write("Origem: ");
            string s = Console.ReadLine();
            int linhaOrigem = int.Parse(s[0] + "");
            int colunaOrigem = int.Parse(s[1] + "");

            Peca origem = Tab.Casa[linhaOrigem, colunaOrigem];
            ValidarOrigem(origem);
            MovimentosPossiveis(origem);

            MoverPeca(linhaOrigem, colunaOrigem);
        }

        public void InfoMenu()
        {
            Console.WriteLine("Turno: " + Turno);
            Console.Write("Jogador: ");
            if (Turno % 2 == 0)
                Console.WriteLine("Preto");
            else
                Console.WriteLine("Branco");
            Console.WriteLine();
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
                    Peca destino = Tab.Casa[linhaDestino, colunaDestino];
                    PreencherCemiterio(origem, destino);
                    Tab.Casa[linha, coluna] = null;
                    origem.Linha = linhaDestino;
                    origem.Coluna = colunaDestino;
                    Tab.Casa[linhaDestino, colunaDestino] = origem;
                    VerificarDama();
                    
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
                    else if(origem is Dama)
                    {
                        if (origem.Cor == Entities.Enums.Cor.Preta && Turno % 2 == 0)
                            return true;
                        else if (origem.Cor == Entities.Enums.Cor.Branca && Turno % 2 == 1)
                            return true;
                    }
                }           
            return false;
        }

        public void MovimentosPossiveis(Peca origem)
        {
            if (origem is Peao)
            {
                if (origem.Cor == Entities.Enums.Cor.Branca && origem.Linha + 1 < Tab.Linhas)
                {
                    if (origem.Coluna + 1 < Tab.Colunas)
                        if (ValidarDestino(origem.Linha + 1, origem.Coluna + 1, origem))
                            Tab.MovimentoPossivel[origem.Linha + 1, origem.Coluna + 1] = true;
                    if (origem.Coluna - 1 >= 0)
                        if (ValidarDestino(origem.Linha + 1, origem.Coluna - 1, origem))
                            Tab.MovimentoPossivel[origem.Linha + 1, origem.Coluna - 1] = true;
                }
                else if (origem.Cor == Entities.Enums.Cor.Preta && origem.Linha - 1 >= 0)
                {
                    if (origem.Coluna + 1 < Tab.Colunas)
                        if (ValidarDestino(origem.Linha - 1, origem.Coluna + 1, origem))
                            Tab.MovimentoPossivel[origem.Linha - 1, origem.Coluna + 1] = true;
                    if (origem.Coluna - 1 >= 0)
                        if (ValidarDestino(origem.Linha - 1, origem.Coluna - 1, origem))
                            Tab.MovimentoPossivel[origem.Linha - 1, origem.Coluna - 1] = true;
                }
            }
            else if (origem is Dama)
            {
                if (origem.Linha-1 >= 0 && origem.Coluna-1 >= 0)
                {
                    if (ValidarDestino(origem.Linha - 1, origem.Coluna - 1, origem))
                        Tab.MovimentoPossivel[origem.Linha - 1, origem.Coluna - 1] = true;
                }
                if (origem.Linha - 1 >= 0 && origem.Coluna +1 < Tab.Colunas)
                {
                    if (ValidarDestino(origem.Linha - 1, origem.Coluna + 1, origem))
                        Tab.MovimentoPossivel[origem.Linha - 1, origem.Coluna + 1] = true;
                }
                if (origem.Linha +1 <Tab.Linhas && origem.Coluna -1 >= 0)
                {
                    if (ValidarDestino(origem.Linha + 1, origem.Coluna - 1, origem))
                        Tab.MovimentoPossivel[origem.Linha + 1, origem.Coluna - 1] = true;
                }
                if (origem.Linha + 1 < Tab.Linhas && origem.Coluna + 1 < Tab.Colunas)
                {
                    if (ValidarDestino(origem.Linha + 1, origem.Coluna + 1, origem))
                        Tab.MovimentoPossivel[origem.Linha + 1, origem.Coluna + 1] = true;
                }
            }

            Console.Clear();
            Console.WriteLine();
            Tab.ImprimirTabuleiro();
            InfoMenu();
        }

        public void VerificarDama()
        {
            //Percorre a primeira linha e a ultima linha da matriz verificando se:
            for (int i = 0; i < Tab.Colunas; i++)
            {                
                //Verificando se há peoes pretos na linha 0. Se sim, transformar em Dama
                if (Tab.Casa[0,i] is Peao && Tab.Casa[0, i].Cor == Cor.Preta) 
                    Tab.Casa[0, i] = new Dama(0, i, Cor.Preta);

                //Verificando se há peoes brancos na ultima linha . Se sim, transformar em Dama
                else if (Tab.Casa[Tab.Linhas - 1, i] is Peao && Tab.Casa[Tab.Linhas - 1, i].Cor == Cor.Branca)
                    Tab.Casa[Tab.Linhas - 1, i] = new Dama(Tab.Linhas - 1, i, Cor.Branca);
            }
        }
        public void PreencherCemiterio(Peca origem, Peca destino)
        {
            //Preenchendo cemiterio de peças para conseguir implementar a situação de vitoria
            if (destino != null && destino.Cor != origem.Cor)
            {
                if (origem.Cor == Entities.Enums.Cor.Branca)
                {
                    CemiterioPretas++;
                }
                else
                    CemiterioBrancas++;
            }

        }


    }
}
