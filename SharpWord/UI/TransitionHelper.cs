using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace SharpWord.UI
{
    public class TransitionHelper
    {
        public static void PopLabel(Label plabel, String ptext, Color pforecolor)
        {
            PopLabel(plabel, ptext, pforecolor, 70);
        }
        public static  void PopLabel(Label plabel, String ptext,Color pforecolor, int iTransactionTime)
        {
            plabel.ForeColor = pforecolor;
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransactionTime));
            
            int OriLeft = plabel.Left;
            int OriTop = plabel.Top;
            int OriHeight = plabel.Height;
            int OriWidth = plabel.Width;
            plabel.Left += 5;
            plabel.Top += 5;
            plabel.Height -= 10;
            plabel.Width -= 10;
            plabel.Text = ptext;
            plabel.ForeColor = Color.Black;
            plabel.Tag = OriLeft;
            t.add(plabel, "Left", OriLeft);
            t.add(plabel, "Top", OriTop);
            t.add(plabel, "Width", OriWidth);
            t.add(plabel, "Height", OriHeight);
            t.Tag = plabel;

            t.run();
            t.TransitionCompletedEvent += T_TransitionCompletedEvent;


        }

        private static  void T_TransitionCompletedEvent(object sender, Transition.Args e)
        {
            Label lbl = (Label)((TransitionExtend)sender).Tag;
            try
            {
                AdjustLeftProperty(lbl, (int)lbl.Tag);
            }catch (Exception ex)
            {
                //Do nothing
            }
        }

        private static  void AdjustLeftProperty(Label plabel, int Left)
        {
            if (plabel.InvokeRequired)
            {
                plabel.Invoke(new Action<Label, int>(AdjustLeftProperty), plabel,Left);
            }
            else
            {
                plabel.Left = Left;
            }
        }
      
        public static void ChangeBackColor(Label plabel,Color ptoColor)
        {
            ChangeBackColor(plabel, ptoColor, 600);
        }
        public static void ChangeBackColor(Label plabel, Color ptoColor, int iTransitionTime)
        {
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransitionTime));
            t.add(plabel, "BackColor", ptoColor);
            t.run();

        }
        public static void RunTransactionIn(Transition tran, int milisecond)
        {
            Timer timer1 = new Timer();
            timer1.Tag = tran;
            timer1.Interval = milisecond;
            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;

        }

        private static void Timer1_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Timer timer1 = (Timer)sender;
            Transition tran = (Transition)timer1.Tag;
            timer1.Enabled = false;
            tran.run();
        }

        public static TransitionExtend  CreateTransactionForLableColor(Label plabel,Color pbackColor, Color pforeColor, int iTransitionTime)
        {
            TransitionExtend t = new TransitionExtend(new TransitionType_EaseInEaseOut(iTransitionTime));
            if(pbackColor != null)
            {
                t.add(plabel, "BackColor", pbackColor);

            }
            if(pforeColor !=null)
            {
                t.add(plabel, "ForeColor", pforeColor );

            }

            // t.run();
            return t;
        }
    }
}
