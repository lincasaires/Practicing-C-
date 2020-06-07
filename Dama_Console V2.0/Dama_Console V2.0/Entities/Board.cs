﻿using Dama_Console_V2._0.Entities.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_Console_V2._0.Entities
{
    class Board
    {
        public Piece[,] Pieces { get; set; }
        public bool[,] PossibleMoves { get; set; }
        public int Lines { get; set; }
        public int Columns { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < Lines; i++)
            {
                
                Console.Write(" " + i + " ");

                for (int j = 0; j< Columns; j++)
                {
                    {
                        if (Pieces[i, j] == null)
                        {
                            Console.Write("- ");
                        }
                        else if (Pieces[i, j].Color == Enums.Colors.Black)
                            ColorChanger.YellowForegroundColor(Pieces[i, j].ToString());
                        else
                            Console.Write(Pieces[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < Columns; i++)
                Console.Write(" " + i);
        }

        public Piece TakePieceOff(Positions pos)
        {
            if (Pieces[pos.Line, pos.Column] == null)
                return null;

            Piece aux = Pieces[pos.Line, pos.Column];
            aux.Position = null;
            Pieces[pos.Line, pos.Column].Position = null;
            return aux;
        }
    }
}
