
namespace ChessGUI
{
    partial class TimerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerWhite = new System.Windows.Forms.Timer(this.components);
            this.timerBlack = new System.Windows.Forms.Timer(this.components);
            this.timeLabelWhite = new System.Windows.Forms.Label();
            this.timeLabalBlack = new System.Windows.Forms.Label();
            this.clockWhite = new ChessGUI.Controls.ChessClock();
            this.clockBlack = new ChessGUI.Controls.ChessClock();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "White";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Black";
            // 
            // timerWhite
            // 
            this.timerWhite.Interval = 1000;
            this.timerWhite.Tick += new System.EventHandler(this.timerWhite_Tick);
            // 
            // timerBlack
            // 
            this.timerBlack.Interval = 1000;
            this.timerBlack.Tick += new System.EventHandler(this.timerBlack_Tick);
            // 
            // timeLabelWhite
            // 
            this.timeLabelWhite.AutoSize = true;
            this.timeLabelWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabelWhite.Location = new System.Drawing.Point(107, 13);
            this.timeLabelWhite.Name = "timeLabelWhite";
            this.timeLabelWhite.Size = new System.Drawing.Size(60, 24);
            this.timeLabelWhite.TabIndex = 2;
            this.timeLabelWhite.Text = "00:00";
            // 
            // timeLabalBlack
            // 
            this.timeLabalBlack.AutoSize = true;
            this.timeLabalBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabalBlack.Location = new System.Drawing.Point(107, 62);
            this.timeLabalBlack.Name = "timeLabalBlack";
            this.timeLabalBlack.Size = new System.Drawing.Size(60, 24);
            this.timeLabalBlack.TabIndex = 3;
            this.timeLabalBlack.Text = "00:00";
            // 
            // clockWhite
            // 
            this.clockWhite.Hours = 9;
            this.clockWhite.Location = new System.Drawing.Point(12, 89);
            this.clockWhite.Minutes = 0;
            this.clockWhite.Name = "clockWhite";
            this.clockWhite.Seconds = 0;
            this.clockWhite.Size = new System.Drawing.Size(163, 163);
            this.clockWhite.TabIndex = 4;
            // 
            // clockBlack
            // 
            this.clockBlack.Hours = 9;
            this.clockBlack.Location = new System.Drawing.Point(181, 89);
            this.clockBlack.Minutes = 0;
            this.clockBlack.Name = "clockBlack";
            this.clockBlack.Seconds = 0;
            this.clockBlack.Size = new System.Drawing.Size(163, 163);
            this.clockBlack.TabIndex = 5;
            // 
            // TimerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 268);
            this.Controls.Add(this.clockBlack);
            this.Controls.Add(this.clockWhite);
            this.Controls.Add(this.timeLabalBlack);
            this.Controls.Add(this.timeLabelWhite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimerView";
            this.Text = "TimerView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerWhite;
        private System.Windows.Forms.Timer timerBlack;
        private System.Windows.Forms.Label timeLabelWhite;
        private System.Windows.Forms.Label timeLabalBlack;
        private Controls.ChessClock clockWhite;
        private Controls.ChessClock clockBlack;
    }
}