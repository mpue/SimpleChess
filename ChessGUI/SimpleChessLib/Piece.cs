using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess
{
    public abstract class Piece
    {
        private int oldX;
        private int oldY;

        public enum Color
        {
            BLACK, 
            WHITE,
            NONE
        }

        public enum Type
        {
            PAWN,
            BISHOP,
            KNIGHT,
            ROOK,
            KING,
            QUEEN, 
            EMPTY
        }

        public abstract int[,] GetSquareTable();

        public bool HasBeenMoved { get; private set; }

        public Position position { get; set; }

        public Piece(Color color, Position pos)
        {
            this.color = color;
            this.type = type;            
            this.position = pos;
        }

        internal void Restore()
        {
            position.col = oldX;
            position.row = oldY;

        }

        internal void Save()
        {
            oldX = position.col;
            oldY = position.row;
        }

        public override int GetHashCode()
        {
            return color.GetHashCode() + type.GetHashCode() + position.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Piece)
            {
                Piece other = obj as Piece;
                return other.color == color && other.type == type && other.position == position;
            }

            return false;
        }

        public Type type { get; set; }
        public Color color { get; private set; }

        public abstract Piece Copy();

        public abstract List<Move> FindPossibleMoves(Board board);

        public abstract bool CanMove(Board board, int fromX, int fromY, int toX, int toY);

        public abstract string GetFen();

        public abstract int GetValue();

    }
}
