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
        public MoveList()
        {
            InitializeComponent();
            listView.Columns.Add(new ColumnHeader("Move"));
        }

        public void SetHistory(IEnumerable<Move> history)
        {
            listView.Items.Clear();
            foreach(Move m in history.Reverse<Move>())
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
    }
}
