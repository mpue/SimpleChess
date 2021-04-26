using ChessGUI.Controls;
using ChessGUI.Properties;
using ilf.pgn;
using ilf.pgn.Data;
using MetroFramework.Forms;
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
using UCI.NET;
using WeifenLuo.WinFormsUI.Docking;

namespace ChessGUI
{
    public partial class ChessBoard : MetroForm
    {
        private ChessGame game;
        private Board board;
        private MoveList moveList;
        private ChessBoardControl chessBoardControl;
        private EvaluationView evaluationView;
        private TimerView timerView;
        private NoteView noteView;
        private ConfigDialog configDialog;
        private ChessConsoleView consoleView;

        public ChessBoard()
        {
            InitializeComponent();

            moveList = new MoveList();
            moveList.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(moveList, true, null);
            chessBoardControl = new ChessBoardControl();
            moveList.GetView().DrawItem += listView_DrawItem;
            moveList.GetView().DrawColumnHeader += listView_DrawColumnHeader;

            moveList.GetView().Columns[0].Width = -2;
            InitMenuItemHandler();

            InitTutorial();
            moveList.GetView().ItemSelectionChanged += HandleItemSelect;

            chessBoardControl.Show(mainDock, DockState.Document);
            moveList.Show(mainDock, DockState.Document);
            moveList.DockTo(mainDock, DockStyle.Right);

            evaluationView = new EvaluationView();
            evaluationView.TabText = "UCI Monitor";
            evaluationView.Show(mainDock, DockState.DockBottom);

            timerView = new TimerView();
            timerView.Show(mainDock, DockState.Document);
            timerView.DockTo(mainDock, DockStyle.Right);

            noteView = new NoteView();
            noteView.Show(mainDock, DockState.Document);
            noteView.DockTo(mainDock, DockStyle.Left);

            moveList.TabText = "Move history";
            configDialog = new ConfigDialog();
            configDialog.TabText = "Configuration";

            consoleView = new ChessConsoleView();
            
            consoleView.Show(mainDock, DockState.DockBottom);
            consoleView.TabText = "Chess console";
        }

        private void HandleLogEvent(object sender, UCIProcess.UCIDataEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                evaluationView.AppendText(e.Message + "\n");

            });
        }

        private void InitMenuItemHandler()
        {
            quitToolStripMenuItem.Click += HandleQuit;
            newGameToolStripMenuItem.Click += HandleNewGame;
            newBoardToolStripMenuItem.Click += HandleNewBoard;
            suggestMoveToolStripMenuItem.Click += HandleSuggestMove;
            undoLastToolStripMenuItem.Click += HandleUndo;
            loadPGNToolStripMenuItem.Click += handleLoadPGN;
            saveUCIToolStripMenuItem.Click += handleSaveUCI;
            editToolStripMenuItem.Click += HandleEdit;
            configurationToolStripMenuItem.Click += HandleConfig;
        }

        private void HandleConfig(object sender, EventArgs e)
        {
            configDialog.Show(mainDock, DockState.Document);
        }

        private void HandleEdit(object sender, EventArgs e)
        {
            chessBoardControl.IsEditing = !chessBoardControl.IsEditing;
        }

        private void HandleNewBoard(object sender, EventArgs e)
        {
            ChessBoardControl bc = new ChessBoardControl();
            
            bc.Show(mainDock, DockState.Document);
        }

        private void handleSaveUCI(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            StringBuilder sb = new StringBuilder();

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                foreach(SimpleChess.Move move in board.history)
                {
                    sb.Append(move + "\n");
                }

                System.IO.File.WriteAllText(sfd.FileName,sb.ToString());
           }


            throw new NotImplementedException();
        }

        private void handleLoadPGN(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    NewGame(true);
                    var reader = new PgnReader();
                    var gameDb = reader.ReadFromFile(ofd.FileName);

                    Game game = gameDb.Games[0];

                    List<string> moves = new List<string>();

                    foreach (var move in game.MoveText.GetMoves())
                    {
                        SimpleChess.Move umove = new SimpleChess.Move(board, move.ToString());
                        umove.Execute();                        
                        this.game.StorePieces();
                    }

                    moveList.SetHistory(board.history);

                    this.game.connector.ResetGame();
                    this.game.connector.SetFenPosition(board.GetFen());
                    this.game.connector.SetPosition(moves.ToArray());
                    Refresh();
                }
            }
        }
        private void HandleItemSelect(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            game.Rewind(e.ItemIndex);
            Refresh();
        }

        private void HandleUndo(object sender, EventArgs e)
        {
            game.connector.ResetGame();
            // game.connector.startNewGame();            
            game.UndoLast();
            moveList.RemoveLast();
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (chessBoardControl != null)
                chessBoardControl.Refresh();
        }

        private void HandleSuggestMove(object sender, EventArgs e)
        {
            string fen = game.connector.GetFenPosition();
            MessageBox.Show("The best move is " + game.connector.GetBestMove(), "Suggestion");
            game.connector.SetFenPosition(fen);
        }

        private void InitTutorial()
        {
            // learnBox.Navigate(new System.Uri(new System.IO.FileInfo(@"text\lesson1_de.html").FullName).AbsoluteUri);
        }

        private void HandleNewGame(object sender, EventArgs e)
        {
            NewGame(true);
        }

        private void NewGame(bool clearHistory)
        {
            board.ResetPieces();
            if (clearHistory)
            {
                board.history.Clear();
            }
            game.connector.ResetGame();
            // game.connector.startNewGame();
            game.connector.SetFenPosition("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            moveList.Clear();
            Refresh();
            timerView.StopTimer();
            timerView.ResetTimers();

            chessBoardControl.LastOpponentMove = null;
            chessBoardControl.ClearSelectiom();
            chessBoardControl.Refresh();
            moveList.ResetCounter();
        }

        private void HandleQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetModel(ChessGame game)
        {
            this.game = game;
            this.board = game.Board;
            game.PieceMoved += HandlePieceMoved;
            game.OnLogEvent += HandleLog;
            if (chessBoardControl != null)
            {
                chessBoardControl.SetModel(game);
            }
            game.connector.CheckMate += HandleCheckMate;
            game.connector.LogEventReceived += HandleLogEvent;
            consoleView.InitInterpreter(game);

        }

        private void HandleCheckMate(object sender, EventArgs e)
        {
            MessageBox.Show("You are checkmate!");
        }

        private void HandleLog(object sender, ChessGame.LogEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // logView.AppendText(e.Message + "\n");

            });

        }

        private void HandlePieceMoved(object sender, ChessGame.PieceMovedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (e.Move != null)
                {
                    if (!timerView.IsStarted)
                    {
                        timerView.StartTimer();
                    }
                    if (e.Move.IsCastle)
                    {
                        // we need to toggle twice in this case, because PieceMoved is called for each piece
                        
                        timerView.ToggleTimer();
                    }
                    timerView.ToggleTimer();
                    moveList.SetHistory(board.history);
                    if (e.Move.capturedPiece != null)
                    {
                        moveList.AddPiece(e.Move.capturedPiece);
                    }
                    // evaluationView.AddEvaluation(e.Move.Score);
                }
                
            });
        }

        private void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if ((e.ItemIndex % 2) == 1)
            {
                e.Item.BackColor = System.Drawing.Color.FromArgb(230, 230, 255);
                e.Item.UseItemStyleForSubItems = true;
            }
        }

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {

        }

        private void LogLabel_Click(object sender, EventArgs e)
        {

        }

        private void learnBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
