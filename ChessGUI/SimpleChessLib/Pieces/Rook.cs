using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    class Rook : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public static readonly int[,] SquareTable =
        {
             { 0,  0,  0,  0,  0,  0,  0,   0 },
             { 10, 20, 20, 20, 20, 20, 20,  10} ,
             {-10,  0,  0,  0,  0,  0,  0, -10} ,
             {-10,  0,  0,  0,  0,  0,  0, -10} ,
             {-10,  0,  0,  0,  0,  0,  0, -10} ,
             {-10,  0,  0,  0,  0,  0,  0, -10} ,
             {-10,  0,  0,  0,  0,  0,  0, -10} ,
             {-30, 30, 40, 10, 10,  0,  0, -30}
        };

        public Rook(Color color, Position pos) : base(color, pos)
        {
            type = Type.ROOK;
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

        public override bool CanMove(Board board, int fromCol, int fromRow, int toCol, int toRow)
        {
            int i;

            // Attempt to move to the same cell
            if (fromRow == toRow && fromCol == toCol)
                return false;

            // Collision detection
            if (fromRow == toRow)
            {
                // Horizontal move
                if (fromCol < toCol)
                {
                    // Move right
                    for (i = fromCol + 1; i <= toCol; ++i)
                        if (board.Pieces[i, fromRow].type != Piece.Type.EMPTY)
                        {
                            if (board.Pieces[i, fromRow].color == color)
                            {
                                return false;
                            }
                        }
                }
                else
                {
                    // Move left
                    for (i = fromCol - 1; i >= toCol; --i)
                        if (board.Pieces[i, fromRow].type != Piece.Type.EMPTY)
                        {
                            if (board.Pieces[i, fromRow].color == color)
                            {
                                return false;
                            }
                        }
                }
            }
            else if (fromCol == toCol)
            {
                // Vertical move
                if (fromRow < toRow)
                {
                    // Move down
                    for (i = fromRow + 1; i <= toRow; ++i)
                        if (board.Pieces[fromCol, i].type != Piece.Type.EMPTY)
                        {
                            if (board.Pieces[fromCol, i].color == color)
                                return false;

                        }
                }
                else
                {
                    // Move up
                    for (i = fromRow - 1; i >= toRow; --i)
                        if (board.Pieces[fromCol, i].type != Piece.Type.EMPTY)
                        {
                            if (board.Pieces[fromCol, i].color == color)
                                return false;

                        }
                }
            }
            else
            {
                // Not a valid rook move (neither horizontal nor vertical)
                return false;
            }

            return true;
        }

        public override Piece Copy()
        {
            return new Rook(color, position);
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "r";
            }
            else if (color == Color.WHITE)
            {
                return "R";
            }
            else
            {
                return "1";
            }
        }

        public override int GetValue()
        {
            return 5;
        }
    }
}
