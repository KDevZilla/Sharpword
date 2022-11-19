using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace SharpWord
{
    public partial class frmSampleTransitions : Form
    {
        public frmSampleTransitions()
        {
            InitializeComponent();
        }

        Timer timerMove = new Timer();
        private int DestinationLeft = 0;
        private int StepSize = 10;
        private int NumberofStep = 40;
        int iCount = 0;
        Utility.TimeMeasure timeMeasure = null;
        private void btnRun_Click(object sender, EventArgs e)
        {
            timeMeasure = new Utility.TimeMeasure();
            timeMeasure.Start();
            lblTran.Left = 30;
            lblNonTran.Left = 30;
            DestinationLeft = lblTran.Left + (StepSize  * NumberofStep);
            StartTranMoving();
            StartNonTranMoving();
        }
        private void StartTranMoving()
        {
            /*
             If timer.Interval is precious this value supposed to be
             1000.
             We use 1285 instead because it tooks about 1.285 seconds 
             for a timer to tick 40 times using interval 25.         
            */
            int Millisecond = 1285;
            Transitions.Transition tran = new Transitions.Transition(new TransitionType_EaseInEaseOut(Millisecond));
            tran.add(lblTran, "Left", DestinationLeft);
            tran.run();
        }
        private void StartNonTranMoving()
        {
            if (timerMove != null)
            {
                timerMove.Enabled = false;
            }
            timerMove = new Timer();
            timerMove.Enabled = true;
            timerMove.Interval = 25;
            timerMove.Tick += TimerMove_Tick;

        }
        private void TimerMove_Tick(object sender, EventArgs e)
        {
            lblNonTran.Left += StepSize; //Walking
            if (lblNonTran.Left >= DestinationLeft) //Reach destination
            {
                timerMove.Enabled = false;
                timeMeasure.Finish();
                this.Text = "Time takes (seconds) " + timeMeasure.TimeTakes.TotalSeconds;
            }
        }
        
    }
}
