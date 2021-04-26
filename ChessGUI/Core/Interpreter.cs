using ChessGUI.Controls;
using SimpleChess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGUI.Core
{
    public class Interpreter
    {
        public ChessGame Game { get; }

        public Interpreter(ChessGame game)
        {
            Game = game;
        }

        public string HandleCommand(string command)
        {
            if (command.Length < 1)
            {
                return "syntax error.";
            }

            string[] tokens = command.Split(' ');

            string subject = tokens[0];

            if (subject == "move")
            {

            }
            if (subject == "getfen")
            {
                return Game.connector.GetFenPosition();
            }
            else if (subject == "fen")
            {
                string fen = tokens[1];
                Game.connector.SetFenPosition(fen);

            }

            else
            {
                Game.connector.send(command+"\n");
            }

            return "Ok.";
        }

    }
}
