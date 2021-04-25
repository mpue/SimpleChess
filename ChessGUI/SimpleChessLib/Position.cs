using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess
{
    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override bool Equals(object obj)
        {

            if (obj is Position)
            {
                Position other = obj as Position;
                return row == other.row && col == other.col;
            }


            return false;
        }

        public override int GetHashCode()
        {
            return row * 10 + col;
        }

    }
}
