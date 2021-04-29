using ChessGUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGUI.Controls
{
    [Designer(typeof(ChessClockDesigner))]
    public partial class ChessClock : UserControl
    {
        Pen secondHandPen = new Pen(Color.Red, 2);
        Pen minuteHandPen = new Pen(Color.Black, 5);
        Pen hourHandPen = new Pen(Color.Black, 5);
        Pen circlePen = new Pen(Color.Black, 2);
        Brush fillBrush = new SolidBrush(Color.FromArgb(64, Color.Green));

        private int seconds;
        private int minutes;
        private int hours;

        [Description("The seconds of the clock"), Category("Data")]
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;
                Refresh();
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
                Refresh();
            }
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
                Refresh();
            }
        }


        public ChessClock()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.clock_bg, 0, 0, Width, Width);            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawArc(circlePen, 5, 5, Width - 10, Height - 10, 0, 360);
            float radius = Width / 2 - 10;

            float sx = (float)(Math.Cos(rad(Seconds * 6 - 90)) * radius) + Width / 2;
            float sy = (float)(Math.Sin(rad(Seconds * 6 - 90)) * radius) + Width / 2;
            float mx = (float)(Math.Cos(rad(Minutes * 6 - 90)) * radius) + Width / 2;
            float my = (float)(Math.Sin(rad(Minutes * 6 - 90)) * radius) + Width / 2;
            float hx = (float)(Math.Cos(rad(Hours * 30 - 90)) * radius * 0.8) + Width / 2;
            float hy = (float)(Math.Sin(rad(Hours * 30 - 90)) * radius * 0.8) + Width / 2;

            e.Graphics.DrawLine(secondHandPen, Width / 2, Height / 2, sx, sy);
            e.Graphics.DrawLine(minuteHandPen, Width / 2, Height / 2, mx, my);
            e.Graphics.DrawLine(hourHandPen, Width / 2, Height / 2, hx, hy);
        }

        private static float deg(double radians)
        {
            return (float)((180 / Math.PI) * radians);
        }

        private static float rad(float degrees)
        {
            return (float)((Math.PI / 180) * degrees);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height;
        }

    }
}
