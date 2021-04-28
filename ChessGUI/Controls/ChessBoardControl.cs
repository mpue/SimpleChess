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
using System.Media;
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

        private Dictionary<Piece.Type, Bitmap> PieceImagesBlack = new Dictionary<Piece.Type, Bitmap>();
        private Dictionary<Piece.Type, Bitmap> PieceImagesWhite = new Dictionary<Piece.Type, Bitmap>();

        public bool IsLocked { get; set; } = false;
        public bool IsEditing { get; set; } = false;

        private bool draggingPiece = false;
        private Piece currentPiece = null;
        private Piece selectedPiece = null;

        private int mouseX;
        private int mouseY;

        private int _col;
        private int _row;

        private int dragStartX;
        private int dragStartY;

        private int pieceStartX;
        private int pieceStartY;

        private int deltaX;
        private int deltaY;

        List<Move> possibleMoves = new List<Move>();

        Pen selectionPen = new Pen(Color.Green, 5);
        Pen movePen = new Pen(Color.Orange, 5);
        Pen suggestionPen = new Pen(Color.Green, 5);
        Brush selectionBrush = new SolidBrush(Color.FromArgb(64, Color.Green));
        Brush moveBrush = new SolidBrush(Color.FromArgb(64, Color.Yellow));
        GraphicsPath capPath = new GraphicsPath();
        private SoundPlayer player;

        public Move LastOpponentMove { get; set; }
        public Move BestMove { get; set; }

        public ChessBoardControl()
        {
            InitializeComponent();
            MouseDown += HandleMouseDown;
            MouseUp += HandleMouseUp;
            MouseMove += HandleMouseMove;
            KeyDown += HandleKeyDown;
            capPath.AddLine(-2, 0, 2, 0);
            capPath.AddLine(-2, 0, 0, 2);
            capPath.AddLine(0, 2, 2, 0);
            movePen.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);
            suggestionPen.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);

            PieceImagesBlack.Add(Piece.Type.BISHOP, Resources.bishop_black);
            PieceImagesBlack.Add(Piece.Type.KING, Resources.king_black);
            PieceImagesBlack.Add(Piece.Type.QUEEN, Resources.queen_black);
            PieceImagesBlack.Add(Piece.Type.ROOK, Resources.rook_black);
            PieceImagesBlack.Add(Piece.Type.PAWN, Resources.pawn_black);
            PieceImagesBlack.Add(Piece.Type.KNIGHT, Resources.knight_black);
            PieceImagesBlack.Add(Piece.Type.EMPTY, null);
            PieceImagesWhite.Add(Piece.Type.BISHOP, Resources.bishop_white);
            PieceImagesWhite.Add(Piece.Type.KING, Resources.king_white);
            PieceImagesWhite.Add(Piece.Type.QUEEN, Resources.queen_white);
            PieceImagesWhite.Add(Piece.Type.ROOK, Resources.rook_white);
            PieceImagesWhite.Add(Piece.Type.PAWN, Resources.pawn_white);
            PieceImagesWhite.Add(Piece.Type.KNIGHT, Resources.knight_white);
            PieceImagesWhite.Add(Piece.Type.EMPTY, null);

            player = new SoundPlayer("move.wav");
            player.Load();
        }

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
            player.Play();
            
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (IsEditing && selectedPiece != null)
                {
                    board.Pieces[selectedPiece.position.col, selectedPiece.position.row] = new Empty(Piece.Color.NONE, selectedPiece.position);
                    Refresh();
                }
            }
        }

        private void HandleMouseMove(object sender, MouseEventArgs e)
        {
            if (IsLocked)
            {
                return;
            }

            mouseX = e.X;
            mouseY = e.Y;

            deltaX = dragStartX - pieceStartX;
            deltaY = dragStartY - pieceStartY;

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
            Task.Run(() =>
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

            }).ContinueWith(result =>
            {             
                this.Invoke((MethodInvoker)delegate
                {
                    Refresh();
                });
            });
                
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (IsLocked)
            {
                return;
            }

            possibleMoves.Clear();

            dragStartX = mouseX;
            dragStartY = mouseY;

            int pieceSize = Width / 8;

            currentPiece = board.Pieces[_col, _row];
            if (currentPiece.type != Piece.Type.EMPTY)
            {
                selectedPiece = currentPiece;
                possibleMoves = currentPiece.FindPossibleMoves(board);

                if (currentPiece != null)
                {
                    draggingPiece = true;

                    pieceStartX = _col * pieceSize;
                    pieceStartY = _row * pieceSize;
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
                foreach (Piece piece in board.Pieces)
                {
                    
                    if (draggingPiece && currentPiece != null && piece == currentPiece)
                    {
                        e.Graphics.FillRectangle(moveBrush, _col * pieceSize, _row * pieceSize, pieceSize, pieceSize);
                        DrawPiece(e, currentPiece, pieceSize, mouseX - (dragStartX - pieceStartX), mouseY - (dragStartY - pieceStartY));

                    }
                    else
                    {
                        DrawPiece(e, piece, pieceSize, piece.position.col * pieceSize, piece.position.row * pieceSize);
                    }
                }

            }

            if (LastOpponentMove != null)
            {


                e.Graphics.DrawLine(movePen, LastOpponentMove.x1 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.y1 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.x2 * pieceSize + pieceSize / 2,
                                        LastOpponentMove.y2 * pieceSize + pieceSize / 2);


            }
            if (BestMove != null)
            {


                e.Graphics.DrawLine(suggestionPen, BestMove.x1 * pieceSize + pieceSize / 2,
                                        BestMove.y1 * pieceSize + pieceSize / 2,
                                        BestMove.x2 * pieceSize + pieceSize / 2,
                                        BestMove.y2 * pieceSize + pieceSize / 2);
            }

        }

        private void DrawPiece(PaintEventArgs e, Piece piece, int pieceSize, int x, int y)
        {
            if (piece.color == Piece.Color.BLACK)
            {
                e.Graphics.DrawImage(PieceImagesBlack[piece.type], x, y, pieceSize, pieceSize);
            }
            else if (piece.color == Piece.Color.WHITE)
            {
                e.Graphics.DrawImage(PieceImagesWhite[piece.type], x, y, pieceSize, pieceSize);
            }
        }

        internal void ClearSelectiom()
        {
            currentPiece = null;
            selectedPiece = null;
        }
    }
}
