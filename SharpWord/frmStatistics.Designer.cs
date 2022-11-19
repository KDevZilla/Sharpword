namespace SharpWord
{
    partial class frmStatistics
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPlayed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatisticMaxSteak = new System.Windows.Forms.Label();
            this.lblStatisticCurrentSteak = new System.Windows.Forms.Label();
            this.lblStatisticWinPercent = new System.Windows.Forms.Label();
            this.lblStatisticPlayed = new System.Windows.Forms.Label();
            this.lblMaxSteak = new System.Windows.Forms.Label();
            this.lblCurrentSteak = new System.Windows.Forms.Label();
            this.lblWinPercent = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblGuessDis6 = new System.Windows.Forms.Label();
            this.lblGuessDis5 = new System.Windows.Forms.Label();
            this.lblGuessDis4 = new System.Windows.Forms.Label();
            this.lblGuessDis3 = new System.Windows.Forms.Label();
            this.lblGuessDis2 = new System.Windows.Forms.Label();
            this.lblGuessDis1 = new System.Windows.Forms.Label();
            this.lblG6 = new System.Windows.Forms.Label();
            this.lblG5 = new System.Windows.Forms.Label();
            this.lblG4 = new System.Windows.Forms.Label();
            this.lblG3 = new System.Windows.Forms.Label();
            this.lblG2 = new System.Windows.Forms.Label();
            this.lblG1 = new System.Windows.Forms.Label();
            this.lblGuessHeader = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(165, 17);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(160, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "STATISTICS";
            // 
            // lblPlayed
            // 
            this.lblPlayed.AutoSize = true;
            this.lblPlayed.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayed.Location = new System.Drawing.Point(17, 161);
            this.lblPlayed.Name = "lblPlayed";
            this.lblPlayed.Size = new System.Drawing.Size(68, 25);
            this.lblPlayed.TabIndex = 1;
            this.lblPlayed.Text = "Played";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatisticMaxSteak);
            this.panel1.Controls.Add(this.lblStatisticCurrentSteak);
            this.panel1.Controls.Add(this.lblStatisticWinPercent);
            this.panel1.Controls.Add(this.lblStatisticPlayed);
            this.panel1.Controls.Add(this.lblMaxSteak);
            this.panel1.Controls.Add(this.lblCurrentSteak);
            this.panel1.Controls.Add(this.lblWinPercent);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.lblPlayed);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 231);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblStatisticMaxSteak
            // 
            this.lblStatisticMaxSteak.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticMaxSteak.Location = new System.Drawing.Point(378, 77);
            this.lblStatisticMaxSteak.Name = "lblStatisticMaxSteak";
            this.lblStatisticMaxSteak.Size = new System.Drawing.Size(111, 65);
            this.lblStatisticMaxSteak.TabIndex = 8;
            this.lblStatisticMaxSteak.Text = "0";
            this.lblStatisticMaxSteak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatisticCurrentSteak
            // 
            this.lblStatisticCurrentSteak.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticCurrentSteak.Location = new System.Drawing.Point(264, 77);
            this.lblStatisticCurrentSteak.Name = "lblStatisticCurrentSteak";
            this.lblStatisticCurrentSteak.Size = new System.Drawing.Size(84, 65);
            this.lblStatisticCurrentSteak.TabIndex = 7;
            this.lblStatisticCurrentSteak.Text = "0";
            this.lblStatisticCurrentSteak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatisticWinPercent
            // 
            this.lblStatisticWinPercent.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticWinPercent.Location = new System.Drawing.Point(89, 77);
            this.lblStatisticWinPercent.Name = "lblStatisticWinPercent";
            this.lblStatisticWinPercent.Size = new System.Drawing.Size(169, 65);
            this.lblStatisticWinPercent.TabIndex = 6;
            this.lblStatisticWinPercent.Text = "0";
            this.lblStatisticWinPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatisticPlayed
            // 
            this.lblStatisticPlayed.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticPlayed.Location = new System.Drawing.Point(-19, 77);
            this.lblStatisticPlayed.Name = "lblStatisticPlayed";
            this.lblStatisticPlayed.Size = new System.Drawing.Size(118, 65);
            this.lblStatisticPlayed.TabIndex = 5;
            this.lblStatisticPlayed.Text = "0";
            this.lblStatisticPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxSteak
            // 
            this.lblMaxSteak.AutoSize = true;
            this.lblMaxSteak.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSteak.Location = new System.Drawing.Point(393, 161);
            this.lblMaxSteak.Name = "lblMaxSteak";
            this.lblMaxSteak.Size = new System.Drawing.Size(56, 50);
            this.lblMaxSteak.TabIndex = 4;
            this.lblMaxSteak.Text = "Max \r\nSteak";
            this.lblMaxSteak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentSteak
            // 
            this.lblCurrentSteak.AutoSize = true;
            this.lblCurrentSteak.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSteak.Location = new System.Drawing.Point(255, 161);
            this.lblCurrentSteak.Name = "lblCurrentSteak";
            this.lblCurrentSteak.Size = new System.Drawing.Size(86, 50);
            this.lblCurrentSteak.TabIndex = 3;
            this.lblCurrentSteak.Text = " Current \r\nSteak";
            this.lblCurrentSteak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWinPercent
            // 
            this.lblWinPercent.AutoSize = true;
            this.lblWinPercent.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinPercent.Location = new System.Drawing.Point(144, 161);
            this.lblWinPercent.Name = "lblWinPercent";
            this.lblWinPercent.Size = new System.Drawing.Size(67, 25);
            this.lblWinPercent.TabIndex = 2;
            this.lblWinPercent.Text = "Win %";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNewGame);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lblGuessDis6);
            this.panel2.Controls.Add(this.lblGuessDis5);
            this.panel2.Controls.Add(this.lblGuessDis4);
            this.panel2.Controls.Add(this.lblGuessDis3);
            this.panel2.Controls.Add(this.lblGuessDis2);
            this.panel2.Controls.Add(this.lblGuessDis1);
            this.panel2.Controls.Add(this.lblG6);
            this.panel2.Controls.Add(this.lblG5);
            this.panel2.Controls.Add(this.lblG4);
            this.panel2.Controls.Add(this.lblG3);
            this.panel2.Controls.Add(this.lblG2);
            this.panel2.Controls.Add(this.lblG1);
            this.panel2.Controls.Add(this.lblGuessHeader);
            this.panel2.Location = new System.Drawing.Point(12, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 395);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(260, 333);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(113, 43);
            this.btnNewGame.TabIndex = 27;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(379, 333);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblGuessDis6
            // 
            this.lblGuessDis6.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis6.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis6.Location = new System.Drawing.Point(50, 268);
            this.lblGuessDis6.Name = "lblGuessDis6";
            this.lblGuessDis6.Size = new System.Drawing.Size(440, 39);
            this.lblGuessDis6.TabIndex = 25;
            this.lblGuessDis6.Text = "0";
            this.lblGuessDis6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGuessDis5
            // 
            this.lblGuessDis5.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis5.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis5.Location = new System.Drawing.Point(50, 226);
            this.lblGuessDis5.Name = "lblGuessDis5";
            this.lblGuessDis5.Size = new System.Drawing.Size(36, 39);
            this.lblGuessDis5.TabIndex = 24;
            this.lblGuessDis5.Text = "0";
            this.lblGuessDis5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGuessDis4
            // 
            this.lblGuessDis4.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis4.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis4.Location = new System.Drawing.Point(50, 184);
            this.lblGuessDis4.Name = "lblGuessDis4";
            this.lblGuessDis4.Size = new System.Drawing.Size(36, 39);
            this.lblGuessDis4.TabIndex = 23;
            this.lblGuessDis4.Text = "0";
            this.lblGuessDis4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGuessDis3
            // 
            this.lblGuessDis3.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis3.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis3.Location = new System.Drawing.Point(50, 142);
            this.lblGuessDis3.Name = "lblGuessDis3";
            this.lblGuessDis3.Size = new System.Drawing.Size(36, 39);
            this.lblGuessDis3.TabIndex = 22;
            this.lblGuessDis3.Text = "0";
            this.lblGuessDis3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGuessDis2
            // 
            this.lblGuessDis2.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis2.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis2.Location = new System.Drawing.Point(50, 100);
            this.lblGuessDis2.Name = "lblGuessDis2";
            this.lblGuessDis2.Size = new System.Drawing.Size(36, 39);
            this.lblGuessDis2.TabIndex = 21;
            this.lblGuessDis2.Text = "0";
            this.lblGuessDis2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGuessDis1
            // 
            this.lblGuessDis1.BackColor = System.Drawing.Color.DimGray;
            this.lblGuessDis1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessDis1.ForeColor = System.Drawing.Color.White;
            this.lblGuessDis1.Location = new System.Drawing.Point(50, 58);
            this.lblGuessDis1.Name = "lblGuessDis1";
            this.lblGuessDis1.Size = new System.Drawing.Size(36, 39);
            this.lblGuessDis1.TabIndex = 20;
            this.lblGuessDis1.Text = "0";
            this.lblGuessDis1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblG6
            // 
            this.lblG6.AutoSize = true;
            this.lblG6.BackColor = System.Drawing.Color.Transparent;
            this.lblG6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG6.Location = new System.Drawing.Point(17, 265);
            this.lblG6.Name = "lblG6";
            this.lblG6.Size = new System.Drawing.Size(22, 25);
            this.lblG6.TabIndex = 7;
            this.lblG6.Text = "6";
            // 
            // lblG5
            // 
            this.lblG5.AutoSize = true;
            this.lblG5.BackColor = System.Drawing.Color.Transparent;
            this.lblG5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG5.Location = new System.Drawing.Point(17, 224);
            this.lblG5.Name = "lblG5";
            this.lblG5.Size = new System.Drawing.Size(22, 25);
            this.lblG5.TabIndex = 6;
            this.lblG5.Text = "5";
            // 
            // lblG4
            // 
            this.lblG4.AutoSize = true;
            this.lblG4.BackColor = System.Drawing.Color.Transparent;
            this.lblG4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG4.Location = new System.Drawing.Point(17, 182);
            this.lblG4.Name = "lblG4";
            this.lblG4.Size = new System.Drawing.Size(22, 25);
            this.lblG4.TabIndex = 5;
            this.lblG4.Text = "4";
            // 
            // lblG3
            // 
            this.lblG3.AutoSize = true;
            this.lblG3.BackColor = System.Drawing.Color.Transparent;
            this.lblG3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG3.Location = new System.Drawing.Point(17, 143);
            this.lblG3.Name = "lblG3";
            this.lblG3.Size = new System.Drawing.Size(22, 25);
            this.lblG3.TabIndex = 4;
            this.lblG3.Text = "3";
            // 
            // lblG2
            // 
            this.lblG2.AutoSize = true;
            this.lblG2.BackColor = System.Drawing.Color.Transparent;
            this.lblG2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG2.Location = new System.Drawing.Point(17, 102);
            this.lblG2.Name = "lblG2";
            this.lblG2.Size = new System.Drawing.Size(22, 25);
            this.lblG2.TabIndex = 3;
            this.lblG2.Text = "2";
            // 
            // lblG1
            // 
            this.lblG1.AutoSize = true;
            this.lblG1.BackColor = System.Drawing.Color.Transparent;
            this.lblG1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG1.Location = new System.Drawing.Point(17, 59);
            this.lblG1.Name = "lblG1";
            this.lblG1.Size = new System.Drawing.Size(22, 25);
            this.lblG1.TabIndex = 2;
            this.lblG1.Text = "1";
            // 
            // lblGuessHeader
            // 
            this.lblGuessHeader.AutoSize = true;
            this.lblGuessHeader.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuessHeader.Location = new System.Drawing.Point(110, 10);
            this.lblGuessHeader.Name = "lblGuessHeader";
            this.lblGuessHeader.Size = new System.Drawing.Size(297, 37);
            this.lblGuessHeader.TabIndex = 1;
            this.lblGuessHeader.Text = "GUESS DISTRIBUTION";
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 654);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmStatistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.frmStatistics_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPlayed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatisticMaxSteak;
        private System.Windows.Forms.Label lblStatisticCurrentSteak;
        private System.Windows.Forms.Label lblStatisticWinPercent;
        private System.Windows.Forms.Label lblStatisticPlayed;
        private System.Windows.Forms.Label lblMaxSteak;
        private System.Windows.Forms.Label lblCurrentSteak;
        private System.Windows.Forms.Label lblWinPercent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblG6;
        private System.Windows.Forms.Label lblG5;
        private System.Windows.Forms.Label lblG4;
        private System.Windows.Forms.Label lblG3;
        private System.Windows.Forms.Label lblG2;
        private System.Windows.Forms.Label lblG1;
        private System.Windows.Forms.Label lblGuessHeader;
        private System.Windows.Forms.Label lblGuessDis1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblGuessDis6;
        private System.Windows.Forms.Label lblGuessDis5;
        private System.Windows.Forms.Label lblGuessDis4;
        private System.Windows.Forms.Label lblGuessDis3;
        private System.Windows.Forms.Label lblGuessDis2;
        private System.Windows.Forms.Button btnNewGame;
    }
}