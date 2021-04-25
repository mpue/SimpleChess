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
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChessBoard board = new ChessBoard();
            ChessGame game = new ChessGame();
            board.SetModel(game);
            board.Refresh();
            Application.Run(board);
        }
    }
}
