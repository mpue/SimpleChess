using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    public class Bishop : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public int[,] SquareTable =
        {
            {-20,-10,-10,-10,-10,-10,-10,-20},
            {-10,  0,  0,  0,  0,  0,  0,-10},
            {-10,  0,  5, 10, 10,  5,  0,-10},
            {-10,  5,  5, 10, 10,  5,  5,-10},
            {-10,  0, 10, 10, 10, 10,  0,-10},
            {-10, 10, 10, 10, 10, 10, 10,-10},
            {-10,  5,  0,  0,  0,  0,  5,-10 },
            { -20,-10,-40,-10,-10,-40,-10,-20 }
        };

        public Bishop(Color color, Position pos) : base(color, pos)
        {
            type = Type.BISHOP;
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            List<Move> moves = new List<Move>();

            if (type != Piece.Type.BISHOP && type != Piece.Type.QUEEN && type != Piece.Type.KING)
            {
                return moves;
            }

            foreach (Piece target in board.Pieces)
            {

                if (!target.Equals(this) && (!target.color.Equals(color))) // not myself and not my color, but empty places
                {
                    if (CanMove(board, position.col, position.row, target.position.col, target.position.row))
                    {
                        moves.Add(new Move(board, position, target.position));
                    }

                }
            }
            return moves;
        }

        public override bool CanMove(Board board, int fromX, int fromY, int toX, int toY)
        {
            int pathLength = Math.Abs(toX - fromX);
            if (pathLength != Math.Abs(toY - fromY)) return false; // Not diagonal
                                                                   // Also validate if the coordinates are in the 0-7 range

            int stepDirectionX = Math.Sign(toX - fromX);
            int stepDirectionY = Math.Sign(toY - fromY);

            // Check all cells before the target
            for (int i = 1; i < pathLength; i++)
            {
                int x = fromX + i * stepDirectionX;
                int y = fromY + i * stepDirectionY;

                if (board.Pieces[x, y].type == Piece.Type.EMPTY) continue; // No obstacles here: keep going
                else return false; // Obstacle found before reaching target: the move is invalid
            }

            // Check target cell
            if (board.Pieces[toX, toY].color != color) return true; // No piece: move is valid

            return false;
        }

        public override Piece Copy()
        {
            return new Bishop(color, position);
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "b";
            }
            else if (color == Color.WHITE) {
                return "B";
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
