using SimpleChess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGUI
{
    static class Program
    {
        static ChessGame chess;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChessBoard board = new ChessBoard();
            chess = new ChessGame();
            board.SetModel(chess);
            board.Refresh();
            // board.WindowState = FormWindowState.Maximized;
            Application.ApplicationExit += OnExit;
            Application.Run(board);
        }

        private static void OnExit(object sender, EventArgs e)
        {
            chess.connector.Quit();
        }
    }
}
