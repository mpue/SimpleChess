using ChessGUI.Properties;
using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using UCI.NET.Core;
using static UCI.NET.Core.UCIClient;

namespace SimpleChess
{
    public class ChessGame
    {
        public UCIClient connector;
        private SoundPlayer player;

        private string lastFenPosition = "";

        public Board Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }

        public class PieceMovedEventArgs : EventArgs
        {
            public PieceMovedEventArgs(Move m)
            {
                Move = m;
            }

            public Move Move { get; private set; }
        }


        public class LogEventArgs : EventArgs
        {
            public LogEventArgs(string m)
            {
                Message = m + "\r\n";
            }

            public string Message { get; private set; }
        }


        public delegate void PieceMovedHandler(object sender, PieceMovedEventArgs e);
        public event PieceMovedHandler PieceMoved;

        public delegate void CheckMateHandler(object sender, PieceMovedEventArgs e);
        public event CheckMateHandler CheckMate;


        public delegate void LogHandler(object sender, LogEventArgs e);
        public event LogHandler OnLogEvent;


        public int MAXDEPTH = 3;

        private bool quit = false;
        private Board board;
        private Move savedMove;

        public ChessGame()
        {
            board = new Board();
            // computeBoard = new Board();
            connector = new UCIClient(@"stockfish.exe");
            // connector = new UCIClient(@"d:\tools\arena\Engines\Ruffian\Ruffian_105.exe");    
            connector.ProcessCompleted += OnMove;
            
            player = new SoundPlayer(Resources.move);
        }

        public void Rewind(int moveIndex)
        {
            board.ResetPieces();
            List<string> moves = new List<string>();

            int index = 0;

            foreach (Move m in board.history)
            {
                if (index == moveIndex)
                {
                    break;

                }
                moves.Add(m.ToString());
                index++;
            }

            board.Pieces = board.pieceHistory[index];

            connector.ResetGame();
            connector.SetPosition(moves.ToArray());
        }


        public void UndoLast()
        {
            board.history.Pop().Undo();

            List<string> moves = new List<string>();

            foreach (Move m in board.history)
            {
                moves.Add(m.ToString());
            }

            connector.ResetGame();
            connector.SetPosition(moves.ToArray());
        }

        private void OnMove(object sender, EventArgs e)
        {
            UCIClientEventArgs args = e as UCIClientEventArgs;
            Move move = new Move(board, args.Move);

            Task.Delay(100).ContinueWith(t =>
            {
                move.Score = args.Score;
                move.Color = Piece.Color.BLACK;
                if (move.Execute())
                {

                    player.PlaySync();                    
                    PieceMoved(this, new PieceMovedEventArgs(move));
                    StorePieces();

                    if (move.ToString() == "e8g8") // castling short black
                    {
                        Move shortCastle = new Move(board, "h8f8");
                        shortCastle.IsCastle = true;
                        shortCastle.Execute();                        
                        PieceMoved(this, new PieceMovedEventArgs(shortCastle));
                    }
                    if (move.ToString() == "e8c8") // castling long black
                    {
                        Move shortCastle = new Move(board, "a8f8");
                        shortCastle.IsCastle = true;
                        shortCastle.Execute();
                        PieceMoved(this, new PieceMovedEventArgs(shortCastle));
                    }
                    lastFenPosition = connector.GetFenPosition();
                    if (board.IsCheckmate(Piece.Color.WHITE))
                    {
                        CheckMate(this, new PieceMovedEventArgs(move));
                    }
                }
            });


        }

        public void StorePieces()
        {
            Piece[,] pieces = new Piece[8, 8];

            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    pieces[col, row] = board.Pieces[col, row].Copy();
                }
            }

            board.pieceHistory.Add(pieces);
        }


        public bool IsValidMove(Move m, Piece p)
        {
            List<Move> possibleMoves = p.FindPossibleMoves(board);

            if (possibleMoves.Contains(m))
            {
                return true;
            }

            return false;
        }

        public void EditMove(Board board, string command)
        {
            Move move = new Move(board, command);
        }

        public void ExecuteMove(Board board, string command, Piece piece)
        {
            Move move = new Move(board, command);
            if (board.IsCheckmate(piece.color))
            {
                CheckMate(this, new PieceMovedEventArgs(move));
                return;
            }

            if (!piece.CanMove(board, move.x1,move.y1, move.x2, move.y2))
            {
                return;
            }

            //if (!IsValidMove(move, piece)) 
            //{
            //    return;
            //}

            player.PlaySync();
            move.Color = Piece.Color.WHITE;

            if (move.Execute())
            {
                if (board.IsInCheck(piece.color))
                {
                    move.Undo();
                    board.history.Pop();

                    return;
                }
        
                StorePieces();
                if (move.ToString() == "e1g1") // castling short white
                {
                    Move shortCastle = new Move(board, "h1f1");
                    shortCastle.IsCastle = true;
                    shortCastle.Execute();
            
                    PieceMoved(this, new PieceMovedEventArgs(shortCastle));
                }
                if (move.ToString() == "e1c1") // castling long white
                {
                    Move shortCastle = new Move(board, "a1g1");
                    shortCastle.IsCastle = true;
                    shortCastle.Execute ();
            
                    PieceMoved(this, new PieceMovedEventArgs(shortCastle));
                }

                string response = connector.Move(move.ToString());
                OnLogEvent(this, new LogEventArgs(response));
                lastFenPosition = connector.GetFenPosition();

                PieceMoved(this, new PieceMovedEventArgs(move));
            }


        }

    }
}
