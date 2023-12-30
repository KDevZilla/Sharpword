using SharpWord.Game;
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
    public partial class frmStatistics : ChildForm
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Statistics statis = new Statistics();
       // public MainUI mainUI = null;

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.letter_w;
            statis = mainUI.CurrentStatistics;
            /*
             //Testing Data
            statis.DisTributeGuess = new int[6];
            statis.DisTributeGuess[0] = 31;
            statis.DisTributeGuess[1] = 5;
            statis.DisTributeGuess[2] = 0;
            statis.DisTributeGuess[3] = 66;
            statis.DisTributeGuess[4] = 20;
            statis.DisTributeGuess[5] = 1;

            statis.Played = 60;
            statis.NumberWin = 45;
            statis.Calculate();
            */

            int MaxValue = statis.DisTributeGuess.Max();
            int MaxIndex = statis.DisTributeGuess.ToList ().IndexOf(MaxValue);
            int MaxWidth = 440;
            int MinWIdth = 36;
            List<Label> lstLableDis = new List<Label>();
            lstLableDis.Add(this.lblGuessDis1);
            lstLableDis.Add(this.lblGuessDis2);
            lstLableDis.Add(this.lblGuessDis3);
            lstLableDis.Add(this.lblGuessDis4);
            lstLableDis.Add(this.lblGuessDis5);
            lstLableDis.Add(this.lblGuessDis6);
            int i;
            if(MaxValue == 0)
            {
                MaxValue = 100;
            }
            int WidthPerScore = (MaxWidth - MinWIdth) / MaxValue ;
            for(i=0;i<lstLableDis.Count;i++)
            {
                int Value = statis.DisTributeGuess[i];
                lstLableDis[i].Width = MinWIdth + (WidthPerScore * Value);
                lstLableDis[i].AutoSize = false;
                lstLableDis[i].Text = Value.ToString();
            }



           

            this.lblStatisticCurrentSteak.Text = statis.CurrentSteak.ToString();
            this.lblStatisticMaxSteak.Text = statis.MaxSteak.ToString();
            this.lblStatisticPlayed.Text = statis.Played.ToString();
            this.lblStatisticWinPercent.Text = statis.WinPercent.ToString();

            RenderTheme();

            mainUI.AdjustChildFromTosmallSizeIfNessecially(this);

        }

        public override void RenderTheme()
        {
            UI.Theme theme = mainUI.CurrentTheme;


            List<Label> listLabel = new List<Label>();

            listLabel.Add(lblG1);
            listLabel.Add(lblG2);
            listLabel.Add(lblG3);
            listLabel.Add(lblG4);
            listLabel.Add(lblG5);
            listLabel.Add(lblG6);



            listLabel.Add(lblStatisticCurrentSteak);
            listLabel.Add(lblStatisticMaxSteak);
            listLabel.Add(lblStatisticPlayed);
            listLabel.Add(lblStatisticWinPercent);

            listLabel.Add(lblPlayed);
            listLabel.Add(lblMaxSteak);
            listLabel.Add(lblCurrentSteak);
            listLabel.Add(lblWinPercent);

            listLabel.Add(lblHeader);
            listLabel.Add(lblGuessHeader);

            List<Label> listLabelDistribute = new List<Label>();
            listLabelDistribute.Add(lblGuessDis1);
            listLabelDistribute.Add(lblGuessDis2);
            listLabelDistribute.Add(lblGuessDis3);
            listLabelDistribute.Add(lblGuessDis4);
            listLabelDistribute.Add(lblGuessDis5);
            listLabelDistribute.Add(lblGuessDis6);

            
            int i;
            for(i=0;i<listLabel.Count;i++)
            {
                listLabel[i].ForeColor = theme.BoardForeColor;
             //   listLabel[i].BackColor = theme.BoardBackColor;
            }
            for(i=0;i<listLabelDistribute.Count;i++)
            {
                listLabelDistribute[i].ForeColor = theme.TileNormalForeColor;
                listLabelDistribute[i].BackColor = theme.TileNormalBackColor;
            }
            if (statis.LatestGuessWinNumber > -1)
            {
                listLabelDistribute[statis.LatestGuessWinNumber].BackColor = theme.TileCorrectBackColor;
                listLabelDistribute[statis.LatestGuessWinNumber].ForeColor = theme.TileCorrectForeColor;
            }

            btnClose.BackColor = theme.ButtonBackColor;
            btnClose.ForeColor = theme.ButtonForeColor;
            btnNewGame.BackColor = theme.ButtonBackColor;
            btnNewGame.ForeColor = theme.ButtonForeColor;

            this.BackColor = theme.PopupFormBackColor;
            Utility.Utility.MakeFormCaptionToBeDarkMode(this, mainUI.CurrentTheme.IsFormCaptionDarkMode);

            //listLabel.Add(labelPlayed);
            //listLabel.Add (label)

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //mainUI.NewGame(null);
            mainUI.mainForm.NewGame();
            this.Close();
        }
    }
}
