using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWord
{
    public partial class frmAbout : ChildForm
    {
        
        public frmAbout()
        {
            InitializeComponent();
        }
        

        //public MainUI mainUI = null;
        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.letter_w;
            this.RenderTheme();

            if (mainUI.CurrentSettings.IsUsingSmallScreen )
            {
                mainUI.AdjustChildFromTosmallSizeIfNessecially(this);
            }
            this.richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            this.linkLabel1.LinkClicked += LinkLabel_LinkClicked;
            this.linkLabel2.LinkClicked += LinkLabel_LinkClicked;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // throw new NotImplementedException();
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public override void RenderTheme()
        {
            this.BackColor = mainUI.CurrentTheme.PopupFormBackColor ;
            this.richTextBox1.BackColor = mainUI.CurrentTheme.PopupFormBackColor;
            this.richTextBox1.ForeColor = mainUI.CurrentTheme.BoardForeColor;
            if (mainUI.CurrentSettings.IsUsingDarkTheme)
            {
                this.linkLabel1.LinkColor = Color.FromArgb(24, 97, 205);
                this.linkLabel2.LinkColor = Color.FromArgb(24, 97, 205);
            }
            Utility.Utility.MakeFormCaptionToBeDarkMode(this, mainUI.CurrentTheme.IsFormCaptionDarkMode);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
