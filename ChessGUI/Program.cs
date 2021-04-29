using ChessGUI.Controls;
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
        static Splash splash;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splash = new Splash();
            splash.Show(); 
            ChessBoard board = new ChessBoard();
            board.Load += OnLoad;
            chess = new ChessGame();
            board.SetModel(chess);
            board.Refresh();
            board.WindowState = FormWindowState.Maximized;
            Application.ApplicationExit += OnExit;
            Application.Run(board);
        }

        private static void OnLoad(object sender, EventArgs e)
        {
            splash.Close();
        }

        private static void OnExit(object sender, EventArgs e)
        {
            chess.connector.Quit();
        }
    }
}
