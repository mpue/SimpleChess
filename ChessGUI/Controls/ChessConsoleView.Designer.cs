
namespace ChessGUI.Controls
{
    partial class ChessConsoleView
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
            this.chessConsole1 = new ChessGUI.Controls.ChessConsole();
            this.SuspendLayout();
            // 
            // chessConsole1
            // 
            this.chessConsole1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chessConsole1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chessConsole1.Location = new System.Drawing.Point(1, -2);
            this.chessConsole1.Multiline = true;
            this.chessConsole1.Name = "chessConsole1";
            this.chessConsole1.Size = new System.Drawing.Size(1455, 920);
            this.chessConsole1.TabIndex = 0;
            // 
            // ChessConsoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 920);
            this.Controls.Add(this.chessConsole1);
            this.Name = "ChessConsoleView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChessConsole chessConsole1;
    }
}
