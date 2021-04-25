using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCI.NET.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace ChessGUI
{
    public partial class EvaluationView : DockContent
    {
        public EvaluationView()
        {
            InitializeComponent();
        }

        public void AddEvaluation(int score)
        {
            textBox1.AppendText(score.ToString()+"\r\n");
        }

        internal void AppendText(string v)
        {
            textBox1.AppendText(v + "\r\n");

        }
    }
}
