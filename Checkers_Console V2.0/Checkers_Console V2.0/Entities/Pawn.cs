using Checkers_Console_V2._0.Entities.Enums;

namespace Checkers_Console_V2._0.Entities
{
    class Pawn:Piece
    {
        public Pawn(Board board,Positions position, Colors color) : base(board,position, color) { }
        


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            int i = Position.Line;
            int j = Position.Column;

            //Black Pawns can move to
            if (Color == Colors.Black)
            {
                //Right Up Diagonal
                if (i - 1 >= 0 && j + 1 < Board.Columns && (Board.Pieces[i - 1, j + 1] == null || Board.Pieces[i - 1, j + 1].Color != Color))
                    if (i - 2 >= 0 && j + 2 < Board.Columns && Board.Pieces[i - 1, j + 1] != null && Board.Pieces[i - 2, j + 2] == null )
                    {
                        TargetFound = true;
                        Target.Add(Board.Pieces[i - 1, j + 1]);
                        mat[i - 1, j + 1] = true;
                        mat[i - 2, j + 2] = true;
                    }
                    else if (Board.Pieces[i - 1, j + 1] == null)
                        mat[i - 1, j + 1] = true;

                //Left Up Diagonal
                if (i - 1 >= 0 && j - 1 >= 0 && (Board.Pieces[i - 1, j - 1] == null || Board.Pieces[i - 1, j - 1].Color != Color))
                    if (i - 2 >= 0 && j - 2 >= 0 && Board.Pieces[i - 1, j - 1] != null && Board.Pieces[i - 2, j - 2] == null )
                    {
                        TargetFound = true;
                        Target.Add(Board.Pieces[i - 1, j - 1]);
                        mat[i - 1, j - 1] = true;
                        mat[i - 2, j - 2] = true;
                    }
                    else if (Board.Pieces[i - 1, j - 1] == null)
                        mat[i - 1, j - 1] = true;
            }

            //White Pawns can move to
            if (Color == Colors.White)
            {
                //Right Down Diagonal
                if (i + 1 < Board.Lines && j + 1 < Board.Columns && (Board.Pieces[i + 1, j + 1] == null || Board.Pieces[i + 1, j + 1].Color != Color))
                    if (i + 2 < Board.Lines && j + 2 < Board.Columns && Board.Pieces[i + 1, j + 1] != null && Board.Pieces[i + 2, j + 2] == null )
                    {
                        TargetFound = true;
                        Target.Add(Board.Pieces[i + 1, j + 1]);
                        mat[i + 1, j + 1] = true;
                        mat[i + 2, j + 2] = true;
                    }
                    else if (Board.Pieces[i + 1, j + 1] == null)
                        mat[i + 1, j + 1] = true;

                //Left Down Diagonal i+1 j-1
                if (i + 1 < Board.Lines && j - 1 >= 0 && (Board.Pieces[i + 1, j - 1] == null || Board.Pieces[i + 1, j - 1].Color != Color))
                    if (i + 2 < Board.Lines && j - 2 >= 0 && Board.Pieces[i + 1, j - 1] != null && Board.Pieces[i + 2, j - 2] == null)
                    {
                        TargetFound = true;
                        Target.Add(Board.Pieces[i + 1, j - 1]);
                        mat[i + 1, j - 1] = true;
                        mat[i + 2, j - 2] = true;
                    }
                    else if (Board.Pieces[i + 1, j - 1] == null)
                        mat[i + 1, j - 1] = true;
            }


            return mat;
        }













        public override string ToString()
        {
            return "P ";
        }
    }
}
