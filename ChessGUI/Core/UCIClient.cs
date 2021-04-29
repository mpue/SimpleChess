using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UCI.NET.Exceptions;
using UCI.NET.Models;
using static UCI.NET.ProcessConnector;

namespace UCI.NET.Core
{
    public class UCIClient
    {
        public event EventHandler ProcessCompleted;
        public event EventHandler CheckMate;

        private List<string> history = new List<string>();

        public delegate void UCILogHandler(object sender, UCIDataEventArgs e);
        public event UCILogHandler LogEventReceived;

        public class UCIClientEventArgs : EventArgs
        {
            public string Move { get; set; }
            public int Score { get; }
            public bool SuggestOnly { get; }

            public UCIClientEventArgs(string move, int score, bool suggestOnly)
            {
                this.Move = move;
                Score = score;
                SuggestOnly = suggestOnly;
            }
        }
        public enum Gamestate
        {
            NORMAL,
            PATT,
            CHECKMATE
        }

        #region private variables

        /// <summary>
        /// 
        /// </summary>
        private const int MAX_TRIES = 200;

        /// <summary>
        /// 
        /// </summary>
        private int _skillLevel;

        private UCIClient.Gamestate _state = UCIClient.Gamestate.NORMAL;


        #endregion

        #region private properties

        /// <summary>
        /// 
        /// </summary>
        private ProcessConnector _uci { get; set; }

        #endregion

        #region public properties

        public UCIClient()
        {

        }

        public void ResetGame()
        {
            history.Clear();
        }

        public string Move(string move)
        {
            if (history.Count > 0 && history.Last().Equals(move))
            {
                // return move;
            }

            history.Add(move);

            SetPosition(history.ToArray());
            
            move = GetBestMove();
            if (move != null)
            {
                history.Add(move);

            }
            Console.WriteLine("...................................");

            foreach (String m in history)
            {
                Console.WriteLine(m);
            }


            return move;
        }

        public bool IsValidMove(string move)
        {
            return IsMoveCorrect(move, history.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        public Settings Settings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Depth { get; set; }


        public UCIClient.Gamestate GetState()
        {
            return _state;
        }


        /// <summary>
        /// 
        /// </summary>
        public int SkillLevel
        {
            get => _skillLevel;
            set
            {
                _skillLevel = value;
                Settings.SkillLevel = SkillLevel;
                setOption("Skill level", SkillLevel.ToString());
                setOption("UCI_AnalyseMode", "true");
            }
        }

        #endregion

        public void Quit()
        {
            _uci.Close();
        }

        # region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="depth"></param>
        /// <param name="settings"></param>
        public UCIClient(
            string path,
            int depth = 2,
            Settings settings = null)
        {
            Depth = depth;
            _uci = new ProcessConnector(path);
            _uci.Start();
            _uci.ReadLine();

            if (settings == null)
            {
                Settings = new Settings();
            }
            else
            {
                Settings = settings;
            }

            // send("uci");

            if (isReady())
            {
                SkillLevel = Settings.SkillLevel;

                foreach (var property in Settings.GetPropertiesAsDictionary())
                {
                    setOption(property.Key, property.Value);
                }

                startNewGame();

                _uci.DataReceived += HandleDataReceived;
                _uci.DataSent += HandleDataReceived;
            }


        }

        private void HandleDataReceived(object sender, ProcessConnector.UCIDataEventArgs e)
        {
            LogEventReceived(this, e);
        }

        #endregion

        #region private

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="estimatedTime"></param>
        public void send(string command, int estimatedTime = 100)
        {
            _uci.WriteLine(command);
            _uci.Wait(estimatedTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        private bool isReady()
        {
            send("isready");
            var tries = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = _uci.ReadLine();
                if (data == "readyok")
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <exception cref="ApplicationException"></exception>
        private void setOption(string name, string value)
        {
            send($"setoption name {name} value {value}");
            if (!isReady())
            {
                throw new ApplicationException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        private string movesToString(string[] moves)
        {
            return string.Join(" ", moves);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public bool startNewGame()
        {
            send("ucinewgame");
            if (isReady())
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void go()
        {
            send($"go depth {Depth}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        private void goTime(int time)
        {
            send($"go movetime {time}", estimatedTime: time + 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<string> readLineAsList()
        {
            var data = _uci.ReadLine();
            if (data != null)
                return data.Split(' ').ToList();
            else
                return new List<string>();
        }

        #endregion

        #region public

        /// <summary>
        /// Setup current position
        /// </summary>
        /// <param name="moves"></param>
        public void SetPosition(params string[] moves)
        {
            startNewGame();
            send($"position startpos moves {movesToString(moves)}");
        }

        /// <summary>
        /// Get visualisation of current position
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public string GetBoardVisual()
        {            
            send("d");

            var board = "";

            var lines = 0;
            var tries = 0;
            while (lines < 17)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = _uci.ReadLine();
                if (data.Contains("+") || data.Contains("|"))
                {
                    lines++;
                    board += $"{data}\n";
                }

                tries++;
            }

            return board;
        }

        /// <summary>
        /// Get position in fen format
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public string GetFenPosition()
        {
            send("d");
            var tries = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    return "";
                }

                var data = readLineAsList();

                if (data == null)
                {
                    return "";
                }

                if (data.Count > 0 && data[0] == "Fen:")
                {
                    return string.Join(" ", data.GetRange(1, data.Count - 1));
                }

                tries++;
            }
        }

        /// <summary>
        /// Set position in fen format
        /// </summary>
        /// <param name="fenPosition"></param>
        public void SetFenPosition(string fenPosition)
        {
            startNewGame();
            send($"position fen {fenPosition}");
        }

        public string MakeSuggestion(string[] moves)
        {
            send($"position startpos moves {movesToString(moves)}");

            while (!isReady())
            {
                Thread.Sleep(100);
            }

            send($"go depth 10");

            while (!isReady())
            {
                Thread.Sleep(100);
            }


            var tries = 0;

            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = readLineAsList();

                if (data[0] == "bestmove")
                {
                    if (data[1] == "(none)")
                    {
                        
                        return null;
                    }
                    else
                    {
                        return data[1];
                    }
                }

                tries++;
            }
            
        }


        /// <summary>
        /// Getting best move of current position
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public string GetBestMove()
        {
            go();

            var tries = 0;
            int score = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = readLineAsList();

                if (data.Contains("info"))
                {
                    if (data[0] == "info")
                    {
                        if (data[4] == "mate")
                        {
                            _state = UCIClient.Gamestate.CHECKMATE;
                        }
                    }
                    
                    if (data.Count >= 10)
                    {
                        if (data.Contains("score"))
                        {
                            try
                            {
                                score = int.Parse(data[9]);
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                    
                }

                if (data[0] == "bestmove")
                {
                    if (data[1] == "(none)")
                    {
                        ProcessCompleted(this, new UCIClient.UCIClientEventArgs("none", score,false));
                        return null;
                    }
                    else
                    {
                        ProcessCompleted(this, new UCIClient.UCIClientEventArgs(data[1], score, false));
                        return data[1];
                    }
                }

                tries++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public string GetBestMoveTime(int time = 1000)
        {
            goTime(time);
            var tries = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = readLineAsList();
                if (data[0] == "bestmove")
                {
                    if (data[1] == "(none)")
                    {
                        return null;
                    }

                    return data[1];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moveValue"></param>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public bool IsMoveCorrect(string move, params string[] history)
        {
            send($"go depth 1 searchmoves {movesToString(history) + " " + move}");
         
            var tries = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = readLineAsList();
                if (data[0] == "bestmove")
                {
                    if (data[1] == "(none)")
                    {
                        return false;
                    }

                    return true;
                }

                tries++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MaxTriesException"></exception>
        public Evaluation GetEvaluation()
        {
            Evaluation evaluation = new Evaluation();
            var fen = GetFenPosition();
            Color compare;
            // fen sequence for white always contains w
            if (fen.Contains("w"))
            {
                compare = Color.White;
            }
            else
            {
                compare = Color.Black;
            }

            // I'm not sure this is the good way to handle evaluation of position, but why not?
            // Another way we need to somehow limit engine depth? 
            goTime(10000);
            var tries = 0;
            while (true)
            {
                if (tries > MAX_TRIES)
                {
                    throw new MaxTriesException();
                }

                var data = readLineAsList();
                if (data[0] == "info")
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i] == "score")
                        {
                            //don't use ternary operator here for readability
                            int k;
                            if (compare == Color.White)
                            {
                                k = 1;
                            }
                            else
                            {
                                k = -1;
                            }

                            evaluation = new Evaluation(data[i + 1], Convert.ToInt32(data[i + 2]) * k);
                        }
                    }
                }

                if (data[0] == "bestmove")
                {
                    return evaluation;
                }

                tries++;
            }
        }



        #endregion
    }
}