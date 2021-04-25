using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    class Pawn : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public static readonly int[,] SquareTable =
        {
            {   0,  0,  0,  0,  0,  0,  0,  0},
            {  50, 50, 50, 50, 50, 50, 50, 50},
            {  10, 10, 20, 30, 30, 20, 10, 10 },
            {   5,  5, 10, 27, 27, 10,  5,  5},
            {   0,  0,  0, 25, 25,  0,  0,  0},
            {   5, -5,-10,  0,  0,-10, -5,  5},
            {   5, 10, 10,-25,-25, 10, 10,  5},
            {   0,  0,  0,  0,  0,  0,  0,  0 }
        };

        public Pawn(Color color, Position pos) : base(color, pos)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            List<Move> moves = new List<Move>();

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
            if (color == Piece.Color.BLACK)
            {

                if (position.row == 1 && toY == 3 && position.col == toX)
                {
                    if (board.Pieces[position.col, position.row + 1].type == Piece.Type.EMPTY)
                    {
                        return true;
                    }
                }

                else if (position.row == toY - 1) // one row ahead
                {
                    if (Math.Abs(position.col - toX) == 1)
                    {
                        if (board.Pieces[toX, toY].type != Piece.Type.EMPTY)
                        {
                            return true;
                        }

                    }
                    else
                    {
                        if (board.Pieces[toX, toY].type == Piece.Type.EMPTY && position.col == toX)
                        {
                            return true;
                        }
                    }

                }
            }
            else
            {
                if (position.row == 6 && toY == 4 && position.col == toX)
                {
                    if (board.Pieces[position.col, position.row - 1].type == Piece.Type.EMPTY)
                    {
                        return true;
                    }
                }
                else if (position.row == toY + 1) // one row ahead
                {
                    if (Math.Abs(position.col - toX) == 1)
                    {
                        if (board.Pieces[toX, toY].type != Piece.Type.EMPTY)
                        {
                            return true;
                        }

                    }
                    else
                    {
                        if (board.Pieces[toX, toY].type == Piece.Type.EMPTY && position.col == toX)
                        {
                            return true;
                        }
                    }
                }

            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Piece Copy()
        {
            return new Pawn(color, position);
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "p";
            }
            else if (color == Color.WHITE)
            {
                return "P";
            }
            else
            {
                return "1";
            }
        }

        public override int GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
