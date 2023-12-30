using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static SharpWord.MainUI;
using SharpWord.UI;

namespace SharpWord
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainUI.Exit();

        }
        MainUI mainUI = new MainUI();
        public void NewGame()
        {
            if (!mainUI.IsGameFinish)
            {
                bool IsShowOnlyOKDialog = false;
                if (mainUI.ShowMessageBox("Do you want to end this current game?", IsShowOnlyOKDialog) !=
                     DialogResult.OK)
                {
                    return;
                }
            }

            mainUI.ClearCurrentGame();
            mainUI.NewGame(this);
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();

        }

        private void vuewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainUI.ViewHelp();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainUI.About();

        }
        public void EnableStatisticsMenu(Boolean IsEnable)
        {
            toolStripMenuStatistics.Enabled = IsEnable;
        }
       // public MainUI mainUI = null;
        private void frmGame_Load(object sender, EventArgs e)
        {
            /*Attribute required for using the icon
             * https://www.flaticon.com/free-icon/letter-w_7786224
             */
            this.Icon = Resource1.letter_w;

            // mainUI.AddMainForm(this);
            mainUI.NewGame(this);
          

        }

       
        private MainUI mUI = null;
        public void SetMainUI(MainUI mainUI)
        {
            //throw new NotImplementedException();
            mUI = mainUI;
        }

        public MainUI GetMainUI()
        {
            // throw new NotImplementedException();
            return mUI;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainUI.Settings();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mainUI.Statistics();

        }


    }
}
