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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }



            




        }
    }
}
