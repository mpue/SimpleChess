using SimpleChess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ChessGUI
{
    public partial class MoveList : DockContent
    {
        private int numBlackQueens = 0;
        private int numBlackRooks = 0;
        private int numBlackKnights = 0;
        private int numBlackBishops = 0;
        private int numBlackPawns = 0;

        private int numWhiteQueens = 0;
        private int numWhiteRooks = 0;
        private int numWhiteKnights = 0;
        private int numWhiteBishops = 0;
        private int numWhitePawns = 0;

        private int scoreBlack = 0;
        private int scoreWhite = 0;

        public MoveList()
        {
            InitializeComponent();
            listView.Columns.Add(new ColumnHeader("Move"));
        }

        public void SetHistory(IEnumerable<Move> history)
        {
            listView.Items.Clear();
            foreach (Move m in history.Reverse<Move>())
            {
                listView.Items.Add(m.ToString());
            }
        }

        public void Clear()
        {
            listView.Items.Clear();
        }

        public void RemoveLast()
        {
            listView.Items.RemoveAt(listView.Items.Count - 1);
        }

        public ListView GetView()
        {
            return listView;
        }

        public void AddPiece(Piece piece)
        {
            if (piece.color == Piece.Color.BLACK)
            {
                switch (piece.type)
                {
                    case Piece.Type.PAWN:
                        numBlackPawns++;
                        break;
                    case Piece.Type.BISHOP:
                        numBlackBishops++;
                        break;
                    case Piece.Type.KNIGHT:
                        numBlackKnights++;
                        break;
                    case Piece.Type.ROOK:
                        numBlackRooks++;
                        break;
                    case Piece.Type.QUEEN:
                        numBlackQueens++;
                        break;
                    default:
                        break;

                }
            }
            else
            {
                switch (piece.type)
                {
                    case Piece.Type.PAWN:
                        numWhitePawns++;
                        break;
                    case Piece.Type.BISHOP:
                        numWhiteBishops++;
                        break;
                    case Piece.Type.KNIGHT:
                        numWhiteKnights++;
                        break;
                    case Piece.Type.ROOK:
                        numWhiteRooks++;
                        break;
                    case Piece.Type.QUEEN:
                        numWhiteQueens++;
                        break;
                    default:
                        break;

                }

            }

            int whiteCaptures = numWhitePawns * 1 + numWhiteBishops * 3 + numWhiteKnights * 3 + numWhiteRooks * 5 + numWhiteQueens * 8;
            int blackCaptures = numBlackPawns * 1 + numBlackBishops * 3 + numBlackKnights * 3 + numBlackRooks * 5 + numBlackQueens * 8;

            if (whiteCaptures > blackCaptures)
            {
                scoreWhite = whiteCaptures - blackCaptures;
            }
            else if (blackCaptures > whiteCaptures)
            {
                scoreBlack = blackCaptures - whiteCaptures;
            }
            else
            {
                scoreBlack = 0;
                scoreWhite = 0;
            }

            UpdateData();
        }

        public void ResetCounter()
        {
            numBlackQueens = 0;
            numBlackRooks = 0;
            numBlackKnights = 0;
            numBlackBishops = 0;
            numBlackPawns = 0;

            numWhiteQueens = 0;
            numWhiteRooks = 0;
            numWhiteKnights = 0;
            numWhiteBishops = 0;
            numWhitePawns = 0;

            scoreBlack = 0;
            scoreWhite = 0;

            UpdateData();
        }

        private void UpdateData()
        {
            pawnBlackCounter.Text = numBlackPawns + "";
            bishopBlackCounter.Text = numBlackBishops + "";
            knightBlackCounter.Text = numBlackKnights + "";
            rookBlackCounter.Text = numBlackRooks + "";
            queenBlackCounter.Text = numBlackQueens + "";
            pawnWhiteCounter.Text = numWhitePawns + "";
            bishopWhiteCounter.Text = numWhiteBishops + "";
            knightWhiteCounter.Text = numWhiteKnights + "";
            rookWhiteCounter.Text = numWhiteRooks + "";
            queenWhiteCounter.Text = numWhiteQueens + "";
            scoreLabelBlack.Text = "+" + scoreWhite;
            scoreLabelWhite.Text = "+" + scoreBlack;

        }
    }

}
