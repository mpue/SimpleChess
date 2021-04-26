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

namespace ChessGUI.Controls
{
    public partial class ChessConsoleView : DockContent
    {
        public ChessConsoleView()
        {
            InitializeComponent();
        }

        public void InitInterpreter(ChessGame game)
        {
            chessConsole1.InitInterpreter(game);
        }
    }
}
