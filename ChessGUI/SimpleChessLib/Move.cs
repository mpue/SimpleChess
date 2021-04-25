using SimpleChess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess
{
    public class Move
    {
        public Board board { get; set; }
        private Piece piece;
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        private bool check = false;
        private bool canMove = true;

        private Piece oldPiece = null;
        private Piece newPiece = null;
        private Piece capturedPiece = null;

        public bool IsCastle { get; set; } = false;


        public int Score { get; set; }

        public Piece.Color Color { get; set; }

        public Move(Board board, int x1, int y1, int x2, int y2)
        {
            this.board = board;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public Move(Move other, Board board)
        {
            this.board = board;
            this.x1 = other.x1;
            this.y1 = other.y1;
            this.x2 = other.x2;
            this.y2 = other.y2;

        }

        public Move(Board board, Position pos, Position target)
        {
            this.board = board;
            this.x1 = pos.col;
            this.y1 = pos.row;
            this.x2 = target.col;
            this.y2 = target.row;
        }

        public Move(Board board, string input)
        {
            this.board = board;
            if (input.Contains("none"))
            {
                canMove = false;
            }
            else
            {
                char[] move = input.ToCharArray();

                this.x1 = Board.getColumnFromLetter(move[0]);
                this.y1 = 8 - Int16.Parse(move[1].ToString());
                this.x2 = Board.getColumnFromLetter(move[2]);
                this.y2 = 8 - Int16.Parse(move[3].ToString());
            }
        }

        public void Undo()
        {
            if (oldPiece != null)
            {
                board.Pieces[oldPiece.position.col, oldPiece.position.row] = oldPiece;
            }

            if (capturedPiece != null)
            {
                board.Pieces[capturedPiece.position.col, capturedPiece.position.row] = capturedPiece;
            }            
            
        }

        public bool Execute()
        {
            board.history.Push(this);

            if (!canMove)
            {
                // return false;
            }

            try
            {
                piece = board.Pieces[x1, y1];

                oldPiece = piece.Copy();

                if (board.Pieces[x2, y2] != null)
                {
                    capturedPiece = board.Pieces[x2, y2];
                }
                else capturedPiece = null;

                if (piece != null && piece.type != Piece.Type.EMPTY)
                {

                    board.Pieces[x2, y2] = piece;
                    board.Pieces[x1, y1] = new Empty(Piece.Color.NONE,  new Position(y1, x1));

                    piece.position = new Position(y2, x2);
                }
                if (piece.type == Piece.Type.PAWN)
                {
                    if(piece.color == Piece.Color.BLACK)
                    {
                        if (y2 == 7)
                        {
                            piece = new Queen(piece.color, piece.position);
                            board.Pieces[x2, y2] = piece;
                        }
                    }
                    else
                    {
                        if (y2 == 0)
                        {
                            piece = new Queen(piece.color, piece.position);
                            board.Pieces[x2, y2] = piece;
                        }

                    }
                }
                else
                {
                    newPiece = piece.Copy();
                }

            }
            catch (Exception e)
            {
                return false;
            }

            if (piece.type == Piece.Type.KING)
            {
                King k = piece as King;
                k.CanCastle = false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is Move)
            {
                Move other = obj as Move;

                return ToString().Equals(other.ToString());
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ColToLetter(x1));

            //if (capturedPiece != null && capturedPiece.type != Piece.Type.EMPTY)
            //{
            //    sb.Append("x");
            //}

            sb.Append((8 - y1).ToString() + ColToLetter(x2) + (8 - y2).ToString());


            return sb.ToString(); 
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public bool IsKingMove()
        {
            return Math.Abs((x1 - x2) * (y1 - y2)) <= 1;
        }

        public static string ColToLetter(int col)
        {
            if (col == 0)
                return "a";
            if (col == 1)
                return "b";
            if (col == 2)
                return "c";
            if (col == 3)
                return "d";
            if (col == 4)
                return "e";
            if (col == 5)
                return "f";
            if (col == 6)
                return "g";
            if (col == 7)
                return "h";
            else return "";
        }
    }
}
