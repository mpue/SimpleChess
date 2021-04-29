using System;
using System.Diagnostics;

namespace UCI.NET
{
    public class ProcessConnector
    {
        /// <summary>
        /// Default process info for Stockfish process
        /// </summary>
        private ProcessStartInfo _processStartInfo { get; set; }

        public class UCIDataEventArgs : EventArgs
        {
            public UCIDataEventArgs(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }

        public delegate void DataReceivedHandler(object sender, UCIDataEventArgs e);
        public event DataReceivedHandler DataReceived;

        public delegate void DataSentHandler(object sender, UCIDataEventArgs e);
        public event DataReceivedHandler DataSent;


        /// <summary>
        /// Stockfish process
        /// </summary>
        private Process _process { get; set; }

        /// <summary>
        /// Stockfish process constructor
        /// </summary>
        /// <param name="path">Path to usable binary file from stockfish site</param>
        public ProcessConnector(string path)
        {
            //TODO: need add method which should be depended on os version
            _processStartInfo = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            _process = new Process {StartInfo = _processStartInfo};
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="millisecond"></param>
        public void Wait(int millisecond)
        {
            this._process.WaitForExit(millisecond);
        }

        /// <summary>
        /// This method is writing in stdin of Stockfish process
        /// </summary>
        /// <param name="command"></param>
        public void WriteLine(string command)
        {
            if (_process.StandardInput == null)
            {
                throw new NullReferenceException();
            }
            if (DataReceived != null)
                DataReceived(this, new UCIDataEventArgs(command));
            // Console.WriteLine(command);
            _process.StandardInput.WriteLine(command);
            _process.StandardInput.Flush();
        }
        
        /// <summary>
        /// This method is allowing to read stdout of Stockfish process
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            if (_process.StandardOutput == null)
            {
                throw new NullReferenceException();
            }
            string output = _process.StandardOutput.ReadLine();
            // Console.WriteLine(output);
            if (DataSent != null)
                DataSent(this, new UCIDataEventArgs(output));
            return output;
        }
        /// <summary>
        /// Start stockfish process
        /// </summary>
        public void Start()
        {
            _process.Start();
        }
        /// <summary>
        /// This method is allowing to close Stockfish process
        /// </summary>
        public void Close()
        {
            //When process is going to be destructed => we are going to close stockfish process
            _process.Close();
        }
    }
}