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
    public partial class frmSettings :ChildForm
    {
        public frmSettings()
        {
            InitializeComponent();
        }
       // public MainUI mainUI = null;
        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.letter_w;
            this.toggleDarkTheme.Checked = this.mainUI.CurrentSettings.IsUsingDarkTheme;
            this.toggleSmallSizeBoard.Checked = this.mainUI.CurrentSettings.IsUsingSmallScreen;
            RenderTheme();


             mainUI.AdjustChildFromTosmallSizeIfNessecially(this);

        }
        public override void RenderTheme()
        {
            this.Visible = false;
            this.BackColor = mainUI.CurrentTheme.PopupFormBackColor;
            this.label1.ForeColor = mainUI.CurrentTheme.BoardForeColor;
            this.label2.ForeColor = mainUI.CurrentTheme.BoardForeColor ;
            this.btnClose.BackColor = mainUI.CurrentTheme.ButtonBackColor;
            this.btnClose.ForeColor = mainUI.CurrentTheme.ButtonForeColor;
            Utility.Utility.MakeFormCaptionToBeDarkMode(this, mainUI.CurrentTheme.IsFormCaptionDarkMode);
            this.Visible = true;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toggleControl1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void toggleControl2_CheckedChanged(object sender, EventArgs e)
        {
            if(this.toggleSmallSizeBoard.Checked)
            {
                if (!mainUI.CurrentSettings.IsUsingSmallScreen )
                {
                    mainUI.CurrentSettings.IsUsingSmallScreen = true;
                    mainUI.SetMainScaleFromNormalToSmall();
                    mainUI.SaveSettings();
                }
            } else
            {
                if (mainUI.CurrentSettings.IsUsingSmallScreen)
                {
                    mainUI.CurrentSettings.IsUsingSmallScreen = false;
                    mainUI.SetMainFormScaleFromSmallToNormal();
                    mainUI.SaveSettings();
                }
            }
            //mainUI.UpdateScale();
           // this.RenderTheme();
        }

        private void toggleControl1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (toggleDarkTheme.Checked)
            {
                if (mainUI.CurrentSettings.IsUsingDarkTheme )
                {
                    return;
                }
                mainUI.CurrentSettings.IsUsingDarkTheme = true;
                mainUI.UpdateGameTheme();
                mainUI.SaveSettings();
                this.RenderTheme();


            }
            else
            {
                if (!mainUI.CurrentSettings.IsUsingDarkTheme)
                {
                    return;
                }
                mainUI.CurrentSettings.IsUsingDarkTheme = false;
                mainUI.UpdateGameTheme();
                mainUI.SaveSettings();
                this.RenderTheme();

            }
        }


    }
}
