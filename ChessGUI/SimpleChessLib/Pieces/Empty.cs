using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess.Pieces
{
    public class Empty : Piece
    {
        public override int[,] GetSquareTable()
        {
            return SquareTable;             
        }

        public int[,] SquareTable =
        {
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0},
            {0, 0,  0,  0,  0,  0,  0,  0}
        };
        public Empty(Color color, Position pos) : base(color, pos)
        {
            type = Type.EMPTY;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override List<Move> FindPossibleMoves(Board board)
        {
            return new List<Move>();
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
            return new Empty(color, position);
        }

        public override bool CanMove(Board board, int fromX, int fromY, int toX, int toY)
        {
            return false;
        }

        public override string GetFen()
        {
            return "1";
        }

        public override int GetValue()
        {
            return 0;
        }
    }
}
