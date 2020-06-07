using Dama_Console.Entities;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Dama_Console
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Partida partida = new Partida();
            

            while (!partida.Terminada)
            {
                try
                {
                    partida.Menu();
                    if (partida.CemiterioBrancas == 15 || partida.CemiterioPretas == 15)
                    {
                        partida.Terminada = true;                       
                    }
                        
                }
                catch(FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Formato incorreto! Use apenas números. Ex: 11 (linha 1 coluna 1)");
                }
                    
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }              
            }
            partida.Tab.ImprimirTabuleiro();
            Console.WriteLine();
            Console.WriteLine("Fim da partida!");
            Console.Write("VENCEDOR: ");
            if (partida.Turno %2 == 0)
                Console.WriteLine("Preto");
            else
                Console.WriteLine("Branco");



            




        }
    }
}
