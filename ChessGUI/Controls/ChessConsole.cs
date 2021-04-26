using ChessGUI.Core;
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
    public partial class ChessConsole : TextBox
    {

        private Interpreter interpreter;

        private List<string> buffers;

        private int row = 0;
        private int col = 0;

        private string currentBuffer = "";

        public ChessConsole()
        {

            InitializeComponent();
            buffers = new List<string>();

            Text = GetBuffer();
            Multiline = true;
            buffers.Add("");
        }

        public void InitInterpreter(ChessGame game)
        {
            interpreter = new Interpreter(game);
        }

        private string GetBuffer()
        {
            StringBuilder sb = new StringBuilder();

            int index = 0;

            foreach (string s in buffers)
            {
                if (index++ < buffers.Count - 1)
                {
                    sb.Append(s+"\r\n");
                }
            }
           
            return sb.ToString();

        }


        protected override void OnKeyUp(KeyEventArgs e)
        {

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                AppendText(e.KeyChar.ToString());
                currentBuffer += e.KeyChar;

                // AppendText(e.KeyChar.ToString());
                e.Handled = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                buffers.Add(currentBuffer);
                row++;
                buffers.Add(interpreter.HandleCommand(buffers[row]));
                buffers.Add("");
                currentBuffer = "";
                Text = GetBuffer();
                SelectionStart = TextLength;
                ScrollToCaret();
                row = buffers.Count - 1;
            }

            

            e.Handled = true;
        }

        
    }

}
