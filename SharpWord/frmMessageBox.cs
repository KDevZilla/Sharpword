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
    public partial class frmMessageBox : ChildForm 
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }
        public String Message
        {
            get { return this.labelMesage.Text; }
            set { this.labelMesage.Text = value; }
        }

        public String  Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        private Boolean _IsShowOKButtonOnly = false;
        public Boolean IsShowOKButtonOnly
        {
            get
            {
                return _IsShowOKButtonOnly;
            }
            set
            {
                _IsShowOKButtonOnly = value;
                SetButtonPosition();
            }
        }
        private void SetButtonPosition()
        {
            if(_IsShowOKButtonOnly)
            {
                btnCancel.Visible = false;
                btnOK.Left = btnCancel.Left;
            } else
            {
                btnCancel.Visible = true;
                btnOK.Left = 329;
            }
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            RenderTheme();
            mainUI.AdjustChildFromTosmallSizeIfNessecially(this);
        }
        public override void RenderTheme()
        {
            this.btnOK.BackColor = mainUI.CurrentTheme.ButtonBackColor;
            this.btnOK.ForeColor = mainUI.CurrentTheme.ButtonForeColor;
            this.btnCancel.BackColor = mainUI.CurrentTheme.ButtonBackColor;
            this.btnCancel.ForeColor = mainUI.CurrentTheme.ButtonForeColor;
            this.BackColor = mainUI.CurrentTheme.PopupFormBackColor;
            this.labelMesage.ForeColor = mainUI.CurrentTheme.BoardForeColor;
            Utility.Utility.MakeFormCaptionToBeDarkMode(this, mainUI.CurrentTheme.IsFormCaptionDarkMode);


        }
    }
}
