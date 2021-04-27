
namespace ChessGUI
{
    partial class ChessBoard
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessBoard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPGNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveUCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suggestMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainDock = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.learnToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.boardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 92);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 6, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2274, 37);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.newBoardToolStripMenuItem,
            this.loadPGNToolStripMenuItem,
            this.saveUCIToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.newGameToolStripMenuItem.Text = "New game";
            // 
            // newBoardToolStripMenuItem
            // 
            this.newBoardToolStripMenuItem.Name = "newBoardToolStripMenuItem";
            this.newBoardToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.newBoardToolStripMenuItem.Text = "New board";
            // 
            // loadPGNToolStripMenuItem
            // 
            this.loadPGNToolStripMenuItem.Name = "loadPGNToolStripMenuItem";
            this.loadPGNToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.loadPGNToolStripMenuItem.Text = "Load PGN";
            // 
            // saveUCIToolStripMenuItem
            // 
            this.saveUCIToolStripMenuItem.Name = "saveUCIToolStripMenuItem";
            this.saveUCIToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.saveUCIToolStripMenuItem.Text = "Save UCI";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // learnToolStripMenuItem
            // 
            this.learnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suggestMoveToolStripMenuItem});
            this.learnToolStripMenuItem.Name = "learnToolStripMenuItem";
            this.learnToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.learnToolStripMenuItem.Text = "Learn";
            // 
            // suggestMoveToolStripMenuItem
            // 
            this.suggestMoveToolStripMenuItem.Name = "suggestMoveToolStripMenuItem";
            this.suggestMoveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.suggestMoveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.suggestMoveToolStripMenuItem.Text = "Suggest move";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoLastToolStripMenuItem});
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // undoLastToolStripMenuItem
            // 
            this.undoLastToolStripMenuItem.Name = "undoLastToolStripMenuItem";
            this.undoLastToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoLastToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.undoLastToolStripMenuItem.Text = "Undo last";
            // 
            // boardToolStripMenuItem
            // 
            this.boardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.boardToolStripMenuItem.Name = "boardToolStripMenuItem";
            this.boardToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.boardToolStripMenuItem.Text = "Board";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.CheckOnClick = true;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(144, 34);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mainDock
            // 
            this.mainDock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDock.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.mainDock.Location = new System.Drawing.Point(20, 157);
            this.mainDock.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.mainDock.Name = "mainDock";
            this.mainDock.Size = new System.Drawing.Size(2276, 1146);
            this.mainDock.TabIndex = 9;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(2314, 1321);
            this.Controls.Add(this.mainDock);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChessBoard";
            this.Padding = new System.Windows.Forms.Padding(20, 92, 20, 20);
            this.Text = "SimpleChess";
            this.Load += new System.EventHandler(this.ChessBoard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem learnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suggestMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoLastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPGNToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel mainDock;
        private System.Windows.Forms.ToolStripMenuItem saveUCIToolStripMenuItem;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.ToolStripMenuItem newBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
    }
}

