namespace SharpWord
{
    partial class frmGame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.vuewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.ToolStripMenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuNew,
            this.toolStripMenuStatistics,
            this.toolStripMenuSettings,
            this.toolStripSeparator1,
            this.ToolStripMenuExit});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newToolStripMenuNew
            // 
            this.newToolStripMenuNew.Name = "newToolStripMenuNew";
            this.newToolStripMenuNew.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuNew.Text = "New";
            this.newToolStripMenuNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuStatistics
            // 
            this.toolStripMenuStatistics.Name = "toolStripMenuStatistics";
            this.toolStripMenuStatistics.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuStatistics.Text = "Stastistics";
            this.toolStripMenuStatistics.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuSettings
            // 
            this.toolStripMenuSettings.Name = "toolStripMenuSettings";
            this.toolStripMenuSettings.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuSettings.Text = "Settings";
            this.toolStripMenuSettings.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuExit
            // 
            this.ToolStripMenuExit.Name = "ToolStripMenuExit";
            this.ToolStripMenuExit.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuExit.Text = "Exit";
            this.ToolStripMenuExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ToolStripMenuHelp
            // 
            this.ToolStripMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vuewHelpToolStripMenuItem,
            this.ToolStripMenuItemAbout});
            this.ToolStripMenuHelp.Name = "ToolStripMenuHelp";
            this.ToolStripMenuHelp.Size = new System.Drawing.Size(44, 20);
            this.ToolStripMenuHelp.Text = "Help";
            // 
            // vuewHelpToolStripMenuItem
            // 
            this.vuewHelpToolStripMenuItem.Name = "vuewHelpToolStripMenuItem";
            this.vuewHelpToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.vuewHelpToolStripMenuItem.Text = "Vew Help";
            this.vuewHelpToolStripMenuItem.Click += new System.EventHandler(this.vuewHelpToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(123, 22);
            this.ToolStripMenuItemAbout.Text = "About";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpWord";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem vuewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuStatistics;
    }
}