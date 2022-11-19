namespace SharpWord
{
    partial class frmShowProblemWIthRoundLabel
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
            this.roundLabel1 = new SharpWord.RoundLabel();
            this.roundLabel2 = new SharpWord.RoundLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundLabel1
            // 
            this.roundLabel1._BackColor = System.Drawing.Color.Empty;
            this.roundLabel1.AutoSize = true;
            this.roundLabel1.BackColor = System.Drawing.Color.Transparent;
            this.roundLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundLabel1.ForeColor = System.Drawing.Color.Black;
            this.roundLabel1.Location = new System.Drawing.Point(37, 51);
            this.roundLabel1.Name = "roundLabel1";
            this.roundLabel1.Size = new System.Drawing.Size(328, 30);
            this.roundLabel1.TabIndex = 0;
            this.roundLabel1.Text = "Round Label No problem on Form";
            // 
            // roundLabel2
            // 
            this.roundLabel2._BackColor = System.Drawing.Color.Empty;
            this.roundLabel2.AutoSize = true;
            this.roundLabel2.BackColor = System.Drawing.Color.Transparent;
            this.roundLabel2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundLabel2.ForeColor = System.Drawing.Color.Black;
            this.roundLabel2.Location = new System.Drawing.Point(37, 191);
            this.roundLabel2.Name = "roundLabel2";
            this.roundLabel2.Size = new System.Drawing.Size(761, 30);
            this.roundLabel2.TabIndex = 1;
            this.roundLabel2.Text = "Round Label Bottom Left corner has problem when being on top of other control";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 44);
            this.label1.TabIndex = 2;
            // 
            // frmShowProblemWIthRoundLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 279);
            this.Controls.Add(this.roundLabel2);
            this.Controls.Add(this.roundLabel1);
            this.Controls.Add(this.label1);
            this.Name = "frmShowProblemWIthRoundLabel";
            this.Text = "ShowProblemWIthRoundLabel";
            this.Load += new System.EventHandler(this.frmShowProblemWIthRoundLabel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundLabel roundLabel1;
        private RoundLabel roundLabel2;
        private System.Windows.Forms.Label label1;
    }
}