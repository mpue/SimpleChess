using SimpleChess.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChess
{
    public class Board
    {
        public Piece[,] Pieces { get; set; }

        public King BlackKing { get; private set; }
        public King WhiteKing { get; private set; }

        public bool CheckMate = false;

        public Stack<Move> history = new Stack<Move>();
        public List<Piece[,]> pieceHistory = new List<Piece[,]>();
        public Board(Board original)
        {
            Pieces = new Piece[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Piece o = original.Pieces[x, y];
                    Pieces[x, y] = o.Copy();
                }

            }
        }

        public Board()
        {
            ResetPieces();
        }

        public void ResetPieces()
        {
            Pieces = new Piece[8, 8];

            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    Pieces[col, row] = new Empty(Piece.Color.NONE, new Position(row, col));
                }
            }

            int index = 0;

            for (int col = 0; col < 8; col++)
            {
                Piece blackPawn = new Pawn(Piece.Color.BLACK, new Position(1, col));
                Pieces[col, 1] = blackPawn;
                Piece whitePawn = new Pawn(Piece.Color.WHITE, new Position(6, col));
                Pieces[col, 6] = whitePawn;
            }

            Pieces[0, 0] = new Rook(Piece.Color.BLACK,   new Position(0, 0));
            Pieces[1, 0] = new Knight(Piece.Color.BLACK, new Position(0, 1));
            Pieces[2, 0] = new Bishop(Piece.Color.BLACK, new Position(0, 2));
            Pieces[3, 0] = new Queen(Piece.Color.BLACK,  new Position(0, 3));
            Pieces[4, 0] = new King(Piece.Color.BLACK,   new Position(0, 4));
            BlackKing = Pieces[4, 0] as King;
            Pieces[5, 0] = new Bishop(Piece.Color.BLACK, new Position(0, 5));
            Pieces[6, 0] = new Knight(Piece.Color.BLACK, new Position(0, 6));
            Pieces[7, 0] = new Rook(Piece.Color.BLACK,   new Position(0, 7));

            Pieces[0, 7] = new Rook(Piece.Color.WHITE,   new Position(7, 0));
            Pieces[1, 7] = new Knight(Piece.Color.WHITE, new Position(7, 1));
            Pieces[2, 7] = new Bishop(Piece.Color.WHITE, new Position(7, 2));
            Pieces[3, 7] = new Queen(Piece.Color.WHITE,  new Position(7, 3));
            Pieces[4, 7] = new King(Piece.Color.WHITE,   new Position(7, 4));
            WhiteKing = Pieces[4, 7] as King;
            Pieces[5, 7] = new Bishop(Piece.Color.WHITE, new Position(7, 5));
            Pieces[6, 7] = new Knight(Piece.Color.WHITE, new Position(7, 6));
            Pieces[7, 7] = new Rook(Piece.Color.WHITE,  new Position(7, 7));

        }

        public float Eval(Piece.Color color)
        {

            int white = 0;
            int black = 0;
            int value = 0;

            int numWhitePawns = 0;
            int numWhiteRooks = 0;
            int numWhiteBishops = 0;
            int numWhiteQueens = 0;
            int numWhiteKnights = 0;

            int numBlackPawns = 0;
            int numBlackRooks = 0;
            int numBlackBishops = 0;
            int numBlackQueens = 0;
            int numBlackKnights = 0;

            int numWhitePawnMoves = 0;
            int numWhiteRooksMoves = 0;
            int numWhiteBishopsMoves = 0;
            int numWhiteQueensMoves = 0;
            int numWhiteKingMoves = 0;
            int numWhiteKnightsMoves = 0;

            int numBlackPawnsMoves = 0;
            int numBlackRooksMoves = 0;
            int numBlackBishopsMoves = 0;
            int numBlackQueensMoves = 0;
            int numBlackKingMoves = 0;
            int numBlackKnightsMoves = 0;

            int mul = 1;

            foreach (Piece p in Pieces)
            {
                switch (p.type)
                {
                    case Piece.Type.PAWN:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackPawns++;
                            numBlackPawnsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhitePawns++;
                            numWhitePawnMoves += p.FindPossibleMoves(this).Count;
                        }
                        break;
                    case Piece.Type.BISHOP:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackBishops++;
                            numBlackBishopsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteBishops++;
                            numWhiteBishopsMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.KNIGHT:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackKnights++;
                            numBlackKnightsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteKnights++;
                            numWhiteKnightsMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.ROOK:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackRooks++;
                            numBlackRooksMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteRooks++;
                            numWhiteRooksMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.KING:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackKingMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteKingMoves += p.FindPossibleMoves(this).Count;
                        }
                        break;
                    case Piece.Type.QUEEN:
                        if (color == Piece.Color.BLACK)
                        {
                            numBlackQueens++;
                            numBlackQueensMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteQueens++;
                            numWhiteQueensMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.EMPTY:
                        break;
                }

            }

            value += 9 * (numWhiteQueens - numBlackQueens) * mul
                  + 5 * (numWhiteRooks - numBlackRooks) * mul
                  + 3 * (numWhiteBishops - numBlackBishops) * mul
                  + 3 * (numWhiteKnights - numBlackKnights) * mul
                  + 1 * (numWhitePawns - numBlackPawns) * mul;

            int mobility = 9 * (numWhiteQueensMoves - numBlackQueensMoves) * mul
                        + 5 * (numWhiteRooksMoves - numBlackRooksMoves) * mul
                        + 3 * (numWhiteBishopsMoves - numBlackBishopsMoves) * mul
                        + 3 * (numWhiteKnightsMoves - numBlackKnightsMoves) * mul
                        + 1 * (numWhitePawnMoves - numBlackPawnsMoves) * mul;


            return (value * mobility) / 100.0f;

        }

        public King FindKing(Piece.Color color)
        {
            foreach (Piece p in this.Pieces)
            {
                if (p.type == Piece.Type.KING)
                {
                    if (color == p.color)
                    {
                        return p as King;
                    }

                }

            }
            // should never happen
            return null;
        }

        internal bool IsCheckmate(Piece.Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            King king = FindKing(color);

            bool canMove = false;

            foreach (Move move in king.FindPossibleMoves(this))
            {
                if (move.Execute())
                {
                    if (!IsInCheck(color))
                    {
                        canMove = true;
                    }
                    move.Undo();
                    history.Pop();                        
                }
            }
            return !canMove;
        }

        public float Eval()
        {

            int white = 0;
            int black = 0;
            int value = 0;

            int numWhitePawns = 0;
            int numWhiteRooks = 0;
            int numWhiteBishops = 0;
            int numWhiteQueens = 0;
            int numWhiteKnights = 0;

            int numBlackPawns = 0;
            int numBlackRooks = 0;
            int numBlackBishops = 0;
            int numBlackQueens = 0;
            int numBlackKnights = 0;

            int numWhitePawnMoves = 0;
            int numWhiteRooksMoves = 0;
            int numWhiteBishopsMoves = 0;
            int numWhiteQueensMoves = 0;
            int numWhiteKingMoves = 0;
            int numWhiteKnightsMoves = 0;

            int numBlackPawnsMoves = 0;
            int numBlackRooksMoves = 0;
            int numBlackBishopsMoves = 0;
            int numBlackQueensMoves = 0;
            int numBlackKingMoves = 0;
            int numBlackKnightsMoves = 0;

            int mul = 1;

            foreach (Piece p in Pieces)
            {
                switch (p.type)
                {
                    case Piece.Type.PAWN:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackPawns++;
                            numBlackPawnsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhitePawns++;
                            numWhitePawnMoves += p.FindPossibleMoves(this).Count;
                        }
                        break;
                    case Piece.Type.BISHOP:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackBishops++;
                            numBlackBishopsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteBishops++;
                            numWhiteBishopsMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.KNIGHT:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackKnights++;
                            numBlackKnightsMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteKnights++;
                            numWhiteKnightsMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.ROOK:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackRooks++;
                            numBlackRooksMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteRooks++;
                            numWhiteRooksMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.KING:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackKingMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteKingMoves += p.FindPossibleMoves(this).Count;
                        }
                        break;
                    case Piece.Type.QUEEN:
                        if (p.color == Piece.Color.BLACK)
                        {
                            numBlackQueens++;
                            numBlackQueensMoves += p.FindPossibleMoves(this).Count;
                        }
                        else
                        {
                            numWhiteQueens++;
                            numWhiteQueensMoves += p.FindPossibleMoves(this).Count;
                        }

                        break;
                    case Piece.Type.EMPTY:
                        break;
                }

            }

            value += 9 * (numWhiteQueens - numBlackQueens) * mul
                  + 5 * (numWhiteRooks - numBlackRooks) * mul
                  + 3 * (numWhiteBishops - numBlackBishops) * mul
                  + 3 * (numWhiteKnights - numBlackKnights) * mul
                  + 1 * (numWhitePawns - numBlackPawns) * mul;

            int mobility = 9 * (numWhiteQueensMoves - numBlackQueensMoves) * mul
                        + 5 * (numWhiteRooksMoves - numBlackRooksMoves) * mul
                        + 3 * (numWhiteBishopsMoves - numBlackBishopsMoves) * mul
                        + 3 * (numWhiteKnightsMoves - numBlackKnightsMoves) * mul
                        + 1 * (numWhitePawnMoves - numBlackPawnsMoves) * mul;


            return (value * mobility) / 100.0f;

        }

        /// <summary>
        /// Returns the Forsyth Edwards Notaion of the current board
        /// <br/>
        /// Example:
        /// <br/>
        /// rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq - 0 1
        /// </summary>
        /// <returns></returns>
        public string GetFen()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = Pieces[col, row];

                    string p = "1";

                    if (piece != null)
                    {
                        p = piece.GetFen();
                        if (piece.color == Piece.Color.WHITE)
                        {
                            sb.Append(p.ToUpper());
                        }
                        else
                        {
                            sb.Append(p);
                        }

                    }
                    else
                    {
                        sb.Append(p);
                    }
                }

                if (row < 7)
                {
                    sb.Append("/");
                }
            }

            sb.Append(" b KQkq - 0 1");


            string fen = sb.ToString();

            for (int i = 0; i < 8;i++)
            {
                fen = fen.Replace("11111111", "8");
                fen = fen.Replace("1111111", "7");
                fen = fen.Replace("111111", "6");
                fen = fen.Replace("11111", "5");
                fen = fen.Replace("1111", "4");
                fen = fen.Replace("111", "3");
                fen = fen.Replace("11", "2");
            }
            
            return fen.ToString();
        }

        public void SetFenPosition(string fen)
        {

        }

        public string PrintBoard()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("+--+--+--+--+--+--+--+--+\n");

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    sb.Append("|");

                    string p = "  ";

                    Piece piece = Pieces[col, row];

                    if (piece != null)
                    {
                        switch (piece.type)
                        {
                            case Piece.Type.PAWN:
                                p = "p ";
                                break;
                            case Piece.Type.BISHOP:
                                p = "b ";
                                break;
                            case Piece.Type.KNIGHT:
                                p = "n ";
                                break;
                            case Piece.Type.ROOK:
                                p = "r ";
                                break;
                            case Piece.Type.KING:
                                p = "k ";
                                break;
                            case Piece.Type.QUEEN:
                                p = "q ";
                                break;
                        }

                        if (piece.color == Piece.Color.WHITE)
                        {
                            sb.Append(p.ToUpper());
                        }
                        else
                        {
                            sb.Append(p);
                        }

                    }
                    else
                    {
                        sb.Append(p);
                    }


                }
                sb.Append("|" + (8 - row) + "\n");
                sb.Append("+--+--+--+--+--+--+--+--+\n");

            }
            sb.Append("+a-+b-+c-+d-+e-+f-+g-+h-+\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            //return PrintBoard();
            return "";

        }

        public static int getColumnFromLetter(char letter)
        {
            int col = 0;

            if (letter == 'a')
            {
                col = 0;
            }
            else if (letter == 'b')
            {
                col = 1;
            }
            else if (letter == 'c')
            {
                col = 2;
            }
            else if (letter == 'd')
            {
                col = 3;
            }
            else if (letter == 'e')
            {
                col = 4;
            }
            else if (letter == 'f')
            {
                col = 5;
            }
            else if (letter == 'g')
            {
                col = 6;
            }
            else if (letter == 'h')
            {
                col = 7;
            }

            return col;

        }

        public bool IsInCheck(Piece.Color color)
        {
            King king = FindKing(color);

            foreach (Piece p in this.Pieces)
            {
                if (p.color != color)
                {
                    if (p.CanMove(this, p.position.col, p.position.row, king.position.col, king.position.row))
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public List<Move> GetPossibleMoves()
        {
            List<Move> possibleMoves = new List<Move>();

            foreach (Piece p in this.Pieces)
            {
                possibleMoves.AddRange(p.FindPossibleMoves(this));
            }

            return possibleMoves;
        }

        public List<Move> GetPossibleMoves(Piece.Color color)
        {
            List<Move> moves = new List<Move>();

            foreach (Piece p in this.Pieces)
            {
                if (p.color != color) { continue; }
                List<Move> possibleMoves = p.FindPossibleMoves(this);
                if (p.type == Piece.Type.KING)
                {
                    if (possibleMoves.Count == 0 && IsInCheck(color))
                    {
                        CheckMate = true;
                        moves.Clear();
                        return moves;
                    }
                }
                moves.AddRange(possibleMoves);
            }

            return moves;
        }

    }

}
