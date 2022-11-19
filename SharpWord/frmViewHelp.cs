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
    public partial class frmViewHelp :  ChildForm
    {
        public frmViewHelp()
        {
            InitializeComponent();
        }
       // public MainUI mainUI = null;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmViewHelp_Load(object sender, EventArgs e)
        {
            this.RenderTheme();

             mainUI.AdjustChildFromTosmallSizeIfNessecially(this);

        }
        public override void RenderTheme()
        {
            UI.Theme theme = mainUI.CurrentTheme;

            this.BackColor = theme.PopupFormBackColor;
            List<Label> lstLabel = new List<Label>();
            lstLabel.Add(label1);
            lstLabel.Add(label2);
            lstLabel.Add(label3);
            lstLabel.Add(label4);
            lstLabel.Add(label5);
            lstLabel.Add(label6);
           // lstLabel.Add(label7);
           // lstLabel.Add(label8);
           // lstLabel.Add(label9);



            int i;
            for (i = 0; i < lstLabel.Count; i++)
            {
                lstLabel[i].ForeColor = theme.BoardForeColor;
            }
            this.lbl11.BackColor = theme.TileCorrectBackColor;
            this.lbl11.ForeColor = theme.TileCorrectForeColor;

            this.lbl23.BackColor = theme.TileNotCorrectPositionBackColor;
            this.lbl23.ForeColor = theme.TileNotCorrectPositionForeColor;

            this.lbl34.BackColor = theme.TileNotExistBackColor;
            this.lbl34.ForeColor = theme.TileNotExistForeColor;

            this.btnClose.BackColor = theme.ButtonBackColor;
            this.btnClose.ForeColor = theme.ButtonForeColor;
            Utility.Utility.MakeFormCaptionToBeDarkMode(this, mainUI.CurrentTheme.IsFormCaptionDarkMode);


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Hide();

        }
    }
}
