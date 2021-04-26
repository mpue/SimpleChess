
namespace ChessGUI
{
    partial class MoveList
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.queenBlackCounter = new System.Windows.Forms.Label();
            this.queenWhiteCounter = new System.Windows.Forms.Label();
            this.rookWhiteCounter = new System.Windows.Forms.Label();
            this.rookBlackCounter = new System.Windows.Forms.Label();
            this.knightWhiteCounter = new System.Windows.Forms.Label();
            this.knightBlackCounter = new System.Windows.Forms.Label();
            this.bishopWhiteCounter = new System.Windows.Forms.Label();
            this.bishopBlackCounter = new System.Windows.Forms.Label();
            this.pawnWhiteCounter = new System.Windows.Forms.Label();
            this.pawnBlackCounter = new System.Windows.Forms.Label();
            this.scoreLabelBlack = new System.Windows.Forms.Label();
            this.scoreLabelWhite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 125);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(527, 964);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "History";
            this.columnHeader1.Width = 150;
            // 
            // queenBlackCounter
            // 
            this.queenBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queenBlackCounter.Image = global::ChessGUI.Properties.Resources.queen_black_32;
            this.queenBlackCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queenBlackCounter.Location = new System.Drawing.Point(13, 13);
            this.queenBlackCounter.Name = "queenBlackCounter";
            this.queenBlackCounter.Size = new System.Drawing.Size(63, 35);
            this.queenBlackCounter.TabIndex = 1;
            this.queenBlackCounter.Text = "0";
            this.queenBlackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // queenWhiteCounter
            // 
            this.queenWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queenWhiteCounter.Image = global::ChessGUI.Properties.Resources.queen_white_32;
            this.queenWhiteCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.queenWhiteCounter.Location = new System.Drawing.Point(13, 64);
            this.queenWhiteCounter.Name = "queenWhiteCounter";
            this.queenWhiteCounter.Size = new System.Drawing.Size(63, 35);
            this.queenWhiteCounter.TabIndex = 2;
            this.queenWhiteCounter.Text = "0";
            this.queenWhiteCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rookWhiteCounter
            // 
            this.rookWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rookWhiteCounter.Image = global::ChessGUI.Properties.Resources.rook_white_32;
            this.rookWhiteCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rookWhiteCounter.Location = new System.Drawing.Point(82, 64);
            this.rookWhiteCounter.Name = "rookWhiteCounter";
            this.rookWhiteCounter.Size = new System.Drawing.Size(63, 35);
            this.rookWhiteCounter.TabIndex = 4;
            this.rookWhiteCounter.Text = "0";
            this.rookWhiteCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rookBlackCounter
            // 
            this.rookBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rookBlackCounter.Image = global::ChessGUI.Properties.Resources.rook_black_32;
            this.rookBlackCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rookBlackCounter.Location = new System.Drawing.Point(82, 13);
            this.rookBlackCounter.Name = "rookBlackCounter";
            this.rookBlackCounter.Size = new System.Drawing.Size(63, 35);
            this.rookBlackCounter.TabIndex = 3;
            this.rookBlackCounter.Text = "0";
            this.rookBlackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // knightWhiteCounter
            // 
            this.knightWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knightWhiteCounter.Image = global::ChessGUI.Properties.Resources.knight_white_32;
            this.knightWhiteCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.knightWhiteCounter.Location = new System.Drawing.Point(151, 64);
            this.knightWhiteCounter.Name = "knightWhiteCounter";
            this.knightWhiteCounter.Size = new System.Drawing.Size(63, 35);
            this.knightWhiteCounter.TabIndex = 6;
            this.knightWhiteCounter.Text = "0";
            this.knightWhiteCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // knightBlackCounter
            // 
            this.knightBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knightBlackCounter.Image = global::ChessGUI.Properties.Resources.knight_black_32;
            this.knightBlackCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.knightBlackCounter.Location = new System.Drawing.Point(151, 13);
            this.knightBlackCounter.Name = "knightBlackCounter";
            this.knightBlackCounter.Size = new System.Drawing.Size(63, 35);
            this.knightBlackCounter.TabIndex = 5;
            this.knightBlackCounter.Text = "0";
            this.knightBlackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bishopWhiteCounter
            // 
            this.bishopWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bishopWhiteCounter.Image = global::ChessGUI.Properties.Resources.bishop_white_32;
            this.bishopWhiteCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bishopWhiteCounter.Location = new System.Drawing.Point(220, 64);
            this.bishopWhiteCounter.Name = "bishopWhiteCounter";
            this.bishopWhiteCounter.Size = new System.Drawing.Size(63, 35);
            this.bishopWhiteCounter.TabIndex = 8;
            this.bishopWhiteCounter.Text = "0";
            this.bishopWhiteCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bishopBlackCounter
            // 
            this.bishopBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bishopBlackCounter.Image = global::ChessGUI.Properties.Resources.bishop_black_32;
            this.bishopBlackCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bishopBlackCounter.Location = new System.Drawing.Point(219, 13);
            this.bishopBlackCounter.Name = "bishopBlackCounter";
            this.bishopBlackCounter.Size = new System.Drawing.Size(63, 35);
            this.bishopBlackCounter.TabIndex = 7;
            this.bishopBlackCounter.Text = "0";
            this.bishopBlackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pawnWhiteCounter
            // 
            this.pawnWhiteCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pawnWhiteCounter.Image = global::ChessGUI.Properties.Resources.pawn_white_32;
            this.pawnWhiteCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pawnWhiteCounter.Location = new System.Drawing.Point(289, 64);
            this.pawnWhiteCounter.Name = "pawnWhiteCounter";
            this.pawnWhiteCounter.Size = new System.Drawing.Size(63, 35);
            this.pawnWhiteCounter.TabIndex = 10;
            this.pawnWhiteCounter.Text = "0";
            this.pawnWhiteCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pawnBlackCounter
            // 
            this.pawnBlackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pawnBlackCounter.Image = global::ChessGUI.Properties.Resources.pawn_black_32;
            this.pawnBlackCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pawnBlackCounter.Location = new System.Drawing.Point(289, 13);
            this.pawnBlackCounter.Name = "pawnBlackCounter";
            this.pawnBlackCounter.Size = new System.Drawing.Size(63, 35);
            this.pawnBlackCounter.TabIndex = 9;
            this.pawnBlackCounter.Text = "0";
            this.pawnBlackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scoreLabelBlack
            // 
            this.scoreLabelBlack.BackColor = System.Drawing.SystemColors.Window;
            this.scoreLabelBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreLabelBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabelBlack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scoreLabelBlack.Location = new System.Drawing.Point(412, 13);
            this.scoreLabelBlack.Name = "scoreLabelBlack";
            this.scoreLabelBlack.Size = new System.Drawing.Size(99, 35);
            this.scoreLabelBlack.TabIndex = 11;
            this.scoreLabelBlack.Text = "0";
            this.scoreLabelBlack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scoreLabelWhite
            // 
            this.scoreLabelWhite.BackColor = System.Drawing.SystemColors.Window;
            this.scoreLabelWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreLabelWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabelWhite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scoreLabelWhite.Location = new System.Drawing.Point(412, 64);
            this.scoreLabelWhite.Name = "scoreLabelWhite";
            this.scoreLabelWhite.Size = new System.Drawing.Size(99, 35);
            this.scoreLabelWhite.TabIndex = 12;
            this.scoreLabelWhite.Text = "0";
            this.scoreLabelWhite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 1103);
            this.Controls.Add(this.scoreLabelWhite);
            this.Controls.Add(this.scoreLabelBlack);
            this.Controls.Add(this.pawnWhiteCounter);
            this.Controls.Add(this.pawnBlackCounter);
            this.Controls.Add(this.bishopWhiteCounter);
            this.Controls.Add(this.bishopBlackCounter);
            this.Controls.Add(this.knightWhiteCounter);
            this.Controls.Add(this.knightBlackCounter);
            this.Controls.Add(this.rookWhiteCounter);
            this.Controls.Add(this.rookBlackCounter);
            this.Controls.Add(this.queenWhiteCounter);
            this.Controls.Add(this.queenBlackCounter);
            this.Controls.Add(this.listView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MoveList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label queenBlackCounter;
        private System.Windows.Forms.Label queenWhiteCounter;
        private System.Windows.Forms.Label rookWhiteCounter;
        private System.Windows.Forms.Label rookBlackCounter;
        private System.Windows.Forms.Label knightWhiteCounter;
        private System.Windows.Forms.Label knightBlackCounter;
        private System.Windows.Forms.Label bishopWhiteCounter;
        private System.Windows.Forms.Label bishopBlackCounter;
        private System.Windows.Forms.Label pawnWhiteCounter;
        private System.Windows.Forms.Label pawnBlackCounter;
        private System.Windows.Forms.Label scoreLabelBlack;
        private System.Windows.Forms.Label scoreLabelWhite;
    }
}
