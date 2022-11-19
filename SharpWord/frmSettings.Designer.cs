namespace SharpWord
{
    partial class frmSettings
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toggleDarkTheme = new SharpWord.ToggleControl();
            this.toggleSmallSizeBoard = new SharpWord.ToggleControl();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Using Small Board";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(227, 153);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "DarkMode";
            // 
            // toggleDarkTheme
            // 
            this.toggleDarkTheme.Location = new System.Drawing.Point(276, 30);
            this.toggleDarkTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toggleDarkTheme.Name = "toggleDarkTheme";
            this.toggleDarkTheme.Padding = new System.Windows.Forms.Padding(9);
            this.toggleDarkTheme.Size = new System.Drawing.Size(63, 32);
            this.toggleDarkTheme.TabIndex = 31;
            this.toggleDarkTheme.Text = "toggleControl1";
            this.toggleDarkTheme.UseVisualStyleBackColor = true;
            this.toggleDarkTheme.CheckedChanged += new System.EventHandler(this.toggleControl1_CheckedChanged_1);
            // 
            // toggleSmallSizeBoard
            // 
            this.toggleSmallSizeBoard.Location = new System.Drawing.Point(276, 93);
            this.toggleSmallSizeBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toggleSmallSizeBoard.Name = "toggleSmallSizeBoard";
            this.toggleSmallSizeBoard.Padding = new System.Windows.Forms.Padding(9);
            this.toggleSmallSizeBoard.Size = new System.Drawing.Size(63, 32);
            this.toggleSmallSizeBoard.TabIndex = 30;
            this.toggleSmallSizeBoard.Text = "toggleControl2";
            this.toggleSmallSizeBoard.UseVisualStyleBackColor = true;
            this.toggleSmallSizeBoard.CheckedChanged += new System.EventHandler(this.toggleControl2_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 208);
            this.Controls.Add(this.toggleDarkTheme);
            this.Controls.Add(this.toggleSmallSizeBoard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private ToggleControl toggleSmallSizeBoard;
        private ToggleControl toggleDarkTheme;
    }
}