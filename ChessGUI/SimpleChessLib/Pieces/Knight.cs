using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    public class Knight : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public static readonly int[,] SquareTable =
        {
            {-50,-40,-30,-30,-30,-30,-40,-50},
            {-40,-20,  0,  0,  0,  0,-20,-40},
            {-30,  0, 10, 15, 15, 10,  0,-30},
            {-30,  5, 15, 20, 20, 15,  5,-30},
            {-30,  0, 15, 20, 20, 15,  0,-30},
            {-30,  5, 10, 15, 15, 10,  5,-30},
            {-40,-20,  0,  5,  5,  0,-20,-40},
            { -50,-40,-20,-30,-30,-20,-40,-50}
        };                                  

        public Knight(Color color, Position pos) : base(color, pos)
        {
            type = Type.KNIGHT;
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            List<Move> moves = new List<Move>();

            foreach (Piece target in board.Pieces)
            {

                if (!target.Equals(this) && (!target.color.Equals(color))) // not myself and not my color, but empty places
                {
                    if (CanMove(board,position.col, position.row, target.position.col, target.position.row))
                    {
                        moves.Add(new Move(board, position, target.position));
                    }

                }
            }
            return moves;
        }

        public override bool CanMove(Board board,int fromX, int fromY, int toX, int toY)
        {
            return Math.Abs((fromX - toX) * (fromY - toY)) == 2;
        }

        public override Piece Copy()
        {
            return new Knight(color, position);
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "n";
            }
            else if (color == Color.WHITE)
            {
                return "N";
            }
            else
            {
                return "1";
            }
        }

        public override int GetValue()
        {
            return 3;
        }
    }
}
