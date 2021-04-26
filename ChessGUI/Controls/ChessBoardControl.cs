using ChessGUI.Properties;
using SimpleChess;
using SimpleChess.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ChessGUI
{
    public partial class ChessBoardControl : DockContent
    {
        private ChessGame game;
        private Board board;

        public bool IsLocked { get; set; } = false;
        public bool IsEditing { get; set; } = false;

        private bool draggingPiece = false;
        private Piece currentPiece = null;
        private Piece selectedPiece = null;

        private int mouseX;
        private int mouseY;

        private int _col;
        private int _row;

        List<Move> possibleMoves = new List<Move>();

        Pen selectionPen = new Pen(Color.Green, 5);
        Pen movePen = new Pen(Color.Orange, 5);
        Brush selectionBrush = new SolidBrush(Color.FromArgb(64, Color.Green));

        GraphicsPath capPath = new GraphicsPath();

        public Move LastOpponentMove { get; set; }

        public void SetModel(ChessGame game)
        {
            this.game = game;
            this.board = game.Board;
            this.game.PieceMoved += HandlePieceMoved;
            this.game.CheckMate += HandleCheckMate;

        }

        private void HandleCheckMate(object sender, ChessGame.PieceMovedEventArgs e)
        {
            MessageBox.Show("You are check mate!");
        }

        private void HandlePieceMoved(object sender, ChessGame.PieceMovedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Move.Color == Piece.Color.BLACK)
                {
                    LastOpponentMove = e.Move;
                }
                Refresh();
            });
        }

        public ChessBoardControl()
        {
            InitializeComponent();
            MouseDown += HandleMouseDown;
            MouseUp += HandleMouseUp;
            MouseMove += HandleMouseMove;
            capPath.AddLine(-2, 0, 2, 0);
            capPath.AddLine(-2, 0, 0, 2);
            capPath.AddLine(0, 2, 2, 0);
            movePen.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);
        }

        private void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (IsLocked)
            {
                return;
            }
            mouseX = e.X;
            mouseY = e.Y;

            int pieceSize = Width / 8;

            _col = mouseX / pieceSize;
            _row = mouseY / pieceSize;

            if (draggingPiece && currentPiece != null)
            {
                Refresh();
            }
        }

        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            if (IsLocked)
            {
                return;
            }

            if (currentPiece == null)
            {
                return;
            }

            draggingPiece = false;

            string command = SimpleChess.Move.ColToLetter(currentPiece.position.col) + (8 - currentPiece.position.row) + SimpleChess.Move.ColToLetter(_col) + (8 - _row);
            if (_col != currentPiece.position.col || _row != currentPiece.position.row)
            {
                if (!IsEditing)
                {
                    game.ExecuteMove(board, command, currentPiece);
                    //LastOpponentMove = null;
                    Refresh();
                    possibleMoves.Clear();
                }
                else
                {
                    game.connector.startNewGame();
                    game.connector.SetFenPosition(board.GetFen());
                    Move move = new Move(board, command);
                    move.Execute();
                }

            }
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (IsLocked)
            {
                return;
            }

            possibleMoves.Clear();

            currentPiece = board.Pieces[_col, _row];
            if (currentPiece.type != Piece.Type.EMPTY)
            {
                selectedPiece = currentPiece;

                possibleMoves = currentPiece.FindPossibleMoves(board);

                if (currentPiece != null)
                {
                    draggingPiece = true;
                }
            }
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int pieceSize = Width / 8;

            if (selectedPiece != null)
            {
                e.Graphics.DrawRectangle(selectionPen, selectedPiece.position.col * pieceSize, selectedPiece.position.row * pieceSize, pieceSize, pieceSize);

                foreach (Move m in possibleMoves)
                {
                    e.Graphics.FillRectangle(selectionBrush, m.x2 * pieceSize, m.y2 * pieceSize, pieceSize, pieceSize);

                }
            }

            if (board != null)
            {
                for (int col = 0; col < 8; col++)
                {
                    for (int row = 0; row < 8; row++)
                    {
                        if (currentPiece != null && draggingPiece)
                        {
                            if (col == currentPiece.position.col && row == currentPiece.position.row)
                            {
                                // currently do nothing
                            }
                            else
                            {
                                DrawPiece(e, board.Pieces[col, row], pieceSize, col, row);
                            }
                        }
                        else
                        {
                            DrawPiece(e, board.Pieces[col, row], pieceSize, col, row);
                        }
                    }
                }

                if (draggingPiece && currentPiece != null)
                {
                    DrawPiece(e, currentPiece, pieceSize, mouseX / pieceSize, mouseY / pieceSize);
                }
            }

            if (LastOpponentMove != null)
            {


                e.Graphics.DrawLine(movePen, LastOpponentMove.x1 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.y1 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.x2 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.y2 * pieceSize + pieceSize / 2);


            }



        }

        private void DrawPiece(PaintEventArgs e, Piece piece, int pieceSize, int col, int row)
        {
            switch (piece.type)
            {
                case Piece.Type.PAWN:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        e.Graphics.DrawImage(Resources.pawn_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Resources.pawn_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    break;
                case Piece.Type.BISHOP:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        e.Graphics.DrawImage(Resources.bishop_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Resources.bishop_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    break;
                case Piece.Type.KNIGHT:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        e.Graphics.DrawImage(Resources.knight_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Resources.knight_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }

                    break;
                case Piece.Type.ROOK:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        e.Graphics.DrawImage(Resources.rook_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Resources.rook_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }

                    break;
                case Piece.Type.KING:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        if (board.IsInCheck(Piece.Color.BLACK))
                        {
                            e.Graphics.DrawImage(Resources.king_black_check, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Resources.king_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                        }
                    }
                    else
                    {
                        if (board.IsInCheck(Piece.Color.WHITE))
                        {
                            e.Graphics.DrawImage(Resources.king_white_check, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                        }
                        else
                        {
                            e.Graphics.DrawImage(Resources.king_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                        }
                    }

                    break;
                case Piece.Type.QUEEN:
                    if (piece.color == Piece.Color.BLACK)
                    {
                        e.Graphics.DrawImage(Resources.queen_black, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Resources.queen_white, col * pieceSize, row * pieceSize, pieceSize, pieceSize);
                    }

                    break;
                case Piece.Type.EMPTY:
                    break;
            }
        }

        internal void ClearSelectiom()
        {
            currentPiece = null;
            selectedPiece = null;
        }
    }
}
