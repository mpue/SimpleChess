using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    public class Queen : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;
        }

        public static readonly int[,] SquareTable =
        {
             {-40, -20, -20, -10, -10, -20, -20, -40  },
             {-20,   0,   0,   0,   0,   0,   0, -20  },
             {-20,   0,  10,  10,  10,  10,   0, -20  },
             {-10,   0,  10,  10,  10,  10,   0, -10  },
             {  0,   0,  10,  10,  10,  10,   0, -10  },
             {-20,  10,  10,  10,  10,  10,   0, -20  },
             {-20,   0,  10,   0,   0,   0,   0, -20  },
             { -40, -20, -20, -10, -10, -20, -20, -40 }
        };

        public Queen(Color color, Position pos) : base(color, pos)
        {
            type = Type.QUEEN;
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            List<Move> moves = new List<Move>();

            foreach (Piece target in board.Pieces)
            {

                if (!target.Equals(this) && !target.color.Equals(color)) // not myself and not my color, but empty places
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
            return (CanMoveLikeBishop(board, fromX, fromY, toX, toY) ||
                CanMoveLikeRook(board, fromX, fromY, toX, toY));
        }

        bool CanMoveLikeBishop(Board board, int fromX, int fromY, int toX, int toY)
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
            if (board.Pieces[toX, toY].type == Piece.Type.EMPTY || board.Pieces[toX, toY].color != color) return true; // No piece: move is valid

            return false;
        }

        bool CanMoveLikeRook(Board board, int fromCol, int fromRow, int toCol, int toRow)
        {
            int i;

            // Attempt to move to the same cell
            if (fromRow == toRow && fromCol == toCol)
                return false;

            bool collides = false;

            // Collision detection
            if (fromRow == toRow)
            {
                // Horizontal move
                if (fromCol < toCol)
                {
                    // Move right
                    for (i = fromCol + 1; i < toCol; ++i)
                        if (board.Pieces[i, fromRow].type != Piece.Type.EMPTY)
                            collides = true;
                }
                else
                {
                    // Move left
                    for (i = fromCol - 1; i > toCol; --i)
                        if (board.Pieces[i, fromRow].type != Piece.Type.EMPTY)
                            collides = true;
                }
            }
            else if (fromCol == toCol)
            {
                // Vertical move
                if (fromRow < toRow)
                {
                    // Move down
                    for (i = fromRow + 1; i < toRow; ++i)
                        if (board.Pieces[fromCol, i].type != Piece.Type.EMPTY)
                            collides = true;
                }
                else
                {
                    // Move up
                    for (i = fromRow - 1; i > toRow; --i)
                        if (board.Pieces[fromCol, i].type != Piece.Type.EMPTY)
                            collides = true;
                }
            }
            else
            {
                // Not a valid rook move (neither horizontal nor vertical)
                return false;
            }
            if (!collides) return true; // No piece: move is valid

            return false;
        }

        public override Piece Copy()
        {
            return new Queen(color, position);
        }

        public override string GetFen()
        {
            if (color == Color.BLACK)
            {
                return "q";
            }
            else if (color == Color.WHITE)
            {
                return "Q";
            }
            else
            {
                return "1";
            }
        }

        public override int GetValue()
        {
            return 9;
        }
    }
}
