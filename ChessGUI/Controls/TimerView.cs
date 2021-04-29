using ChessGUI.Controls;
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
    public partial class TimerView : DockContent
    {
        private int ticksWhite;
        private int ticksBlack;

        public TimerView()
        {
            InitializeComponent();
        }

        private void timerWhite_Tick(object sender, EventArgs e)
        {
            ticksWhite++;
            SetTime(timeLabelWhite, ticksWhite);
            int minutes = ticksWhite / 60;
            int seconds = (ticksWhite - minutes) % 60;
            SetTime(clockWhite, 0, minutes, seconds);
        }

        private void timerBlack_Tick(object sender, EventArgs e)
        {
            ticksBlack++;
            SetTime(timeLabalBlack, ticksBlack);
            int minutes = ticksBlack / 60;
            int seconds = (ticksBlack - minutes) % 60;
            SetTime(clockBlack, 0, minutes, seconds);

        }

        private void SetTime(ChessClock_ clock, int hours, int minutes, int seconds)
        {
            clock.Seconds = seconds;
            clock.Minutes = minutes;
            clock.Hours = hours;
        }

        private void SetTime(Label label, int ticks)
        {
            int minutes = ticks / 60;
            int seconds = (ticks - minutes) % 60;

            StringBuilder s = new StringBuilder();

            if (minutes < 10)
            {
                s.Append("0");
            }
            s.Append(minutes);
            s.Append(":");
            
            if (seconds < 10)
            {
                s.Append("0");
            }
            s.Append(seconds);

            label.Text = s.ToString();
        }


        public void ResetTimers()
        {            
            ticksWhite = 0;
            ticksBlack = 0;
            SetTime(timeLabelWhite, ticksWhite);
            SetTime(timeLabalBlack, ticksBlack);
            SetTime(clockBlack, 0, 0, 0);
            SetTime(clockWhite, 0, 0, 0);
        }

        public void StartTimer()
        {
            if (!IsStarted)
            {
                timerWhite.Enabled = true;
                IsStarted = true;
            }
        }

        public void ToggleTimer()
        {
            timerWhite.Enabled = !timerWhite.Enabled;
            timerBlack.Enabled = !timerBlack.Enabled;
        }

        public void StopTimer()
        {
            timerWhite.Enabled = false;
            timerBlack.Enabled = false;
            IsStarted = false;
        }

        public bool IsStarted { get; set; } = false;
    }
}
