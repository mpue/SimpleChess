using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    public class King : Piece
    {
        public bool CanCastle { get; set; } = true;

        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public static readonly int[,] SquareTable =
        {
          {-30, -40, -40, -50, -50, -40, -40, -30 },
          {-30, -40, -40, -50, -50, -40, -40, -30},
          {-30, -40, -40, -50, -50, -40, -40, -30},
          {-30, -40, -40, -50, -50, -40, -40, -30},
          {-20, -30, -30, -40, -40, -30, -30, -20},
          {-10, -20, -20, -20, -20, -20, -20, -10},
          { 20,  20,   0,   0,   0,   0,  20,  20},
          { 20,  30,  10,   0,   0,  10,  30,  20}
        };

        public King(Color color, Position pos) : base(color, pos)
        {
            type = Piece.Type.KING;
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            List<Move> moves = new List<Move>();

            foreach (Piece target in board.Pieces)
            {
                if (!target.Equals(this) && !target.color.Equals(color)) // not myself and not my color, but empty places
                {
                    if (CanMove(board, position.col, position.row, target.position.col, target.position.row)) 
                        moves.Add(new Move(board, position, target.position));

                }
            }
            return moves;
        }

        public override bool CanMove(Board board, int fromX, int fromY, int toX, int toY)
        {
            if (CanCastle)
            {
                if (color == Color.WHITE)
                {
                    if (fromX == 4 && toX == 6 && fromY == toY && fromY == 7)
                    {
                        return true;
                    }

                }
                else
                {
                    if (fromX == 4 && toX == 6 && fromY == toY && fromY == 0)
                    {
                        return true;
                    }

                }
            }

            if (Math.Abs(fromX - toX) <= 1 &&
                Math.Abs(fromY - toY) <= 1)
            {
                if (board.Pieces[toX, toY].color != color)
                {
                    return true;
                }

            }
            return false;
        }

        public override Piece Copy()
        {
            return new King(color, position);        
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "k";
            }
            else if (color == Color.WHITE)
            {
                return "K";
            }
            else
            {
                return "1";
            }
        }

        public override int GetValue()
        {
            return 100;
        }
    }
}
