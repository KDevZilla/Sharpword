using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Transitions;

namespace SharpWord.UI
{
    public class SwapLabel
    {
        
        public object Tag = null;
        public List<Label> labelList = new List<Label>();
        int CurrentarrLabelSwapIndex = 0;
        private Graphics GraphicRender = null;
        private Color GraphicBackColor;
        public event EventHandler Complete;
        public struct LabelAttribute
        {
            public Color BackColor;
            public Color ForeColor;
            public String Text; 
        }
        
        private void Paint_SwapLabel(object sender, PaintEventArgs e)
        {
            // throw new NotImplementedException();
            try
            {
                SharpWord.UI.DoubleBufferedPanel panel = (SharpWord.UI.DoubleBufferedPanel)sender;
                e.Graphics.Clear(panel.BackColor);
                e.Graphics.DrawImage(panel.DrawImage, panel.NewDes);
            }catch (Exception ex)
            {
                //Do nothing in case of image is swapping too fast, it migth throw an exception
            }
            

        }

        public void SwapNotUsingTimer(SharpWord.UI.DoubleBufferedPanel  pp, List<Label> pLabelList, int pMilisecondThreadSleep)
        {
            pp.Paint += Paint_SwapLabel;
            try
            {
                labelList = pLabelList;

                if (pMilisecondThreadSleep == -1)
                {
                    pMilisecondThreadSleep = 15;
                }
                int MilisecondSleepBetwenPile = pMilisecondThreadSleep * 15;
                int MilisecondThreadSleepBackCard = Convert.ToInt32(pMilisecondThreadSleep * 1.5);

                CurrentarrLabelSwapIndex = 0;
                Boolean IsProcessing = true;
                iYChange = 2;
                int iTemp = 0;
                while (IsProcessing)
                {
                    if (IsShowBackCard)
                    {
                        System.Threading.Thread.Sleep(MilisecondThreadSleepBackCard );
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(pMilisecondThreadSleep);
                    }

                     Application.DoEvents();

                    Label L = labelList[CurrentarrLabelSwapIndex];
                    LabelAttribute NewAttribute = (LabelAttribute)L.Tag;
                    int inumerator = L.Height / iYChange;

                    iTemp++;
                    iTemp = 0;
                    if (LoopCount == 0)
                    {
                        L.Visible = false;
                    }

                    Bitmap b = new Bitmap(L.Width, L.Height);
                    L.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

                    Image image = b;

                    LoopCount++;

                    Point[] NewDes = {
new Point(L.Left , L.Top ),   // destination for upper-left point of
                      // original
new Point(L.Left + L.Width, L.Top ),  // destination for upper-right point of
                      // original
new Point(L.Left , L.Top + L.Height)};  // destination for lower-left point of
                                        // original


                    if (IsShowBackCard)
                    {
                        NewDes[0].Y = L.Top + (iYChange * (inumerator - LoopCount));
                        L.BackColor = NewAttribute.BackColor;
                        L.ForeColor = NewAttribute.ForeColor;
                    }
                    else
                    {
                        NewDes[0].Y = L.Top + (iYChange * LoopCount);
                    }

                    if (LoopCount == 1)
                    {
                        FirstY = L.Top;// NewDes[0].Y;
                    }
                    NewDes[1].Y = NewDes[0].Y;
                    if (IsShowBackCard)
                    {
                        NewDes[2].Y = L.Top + L.Height - (iYChange * (inumerator - LoopCount));
                    }
                    else
                    {
                        NewDes[2].Y = L.Top + L.Height - (iYChange * LoopCount);
                    }
                    pp.DrawImage = image;
                    pp.NewDes = NewDes;
                    pp.Invalidate();
                   
                    if (NewDes[0].Y > NewDes[2].Y)
                    {
                        IsShowBackCard = true;
                    }
                    if (NewDes[0].Y <= FirstY)
                    {
                        if (IsShowBackCard)
                        {
                            LoopCount = 0;
                            L.Visible = true;
                            Application.DoEvents();
                            if (CurrentarrLabelSwapIndex < labelList.Count - 1)
                            {
                                System.Threading.Thread.Sleep(MilisecondSleepBetwenPile);
                                IsShowBackCard = false;
                                CurrentarrLabelSwapIndex++;
                            }
                            else
                            {
                                IsProcessing = false;
                            }

                        }
                    }
                }
            } catch (Exception ex)
            {
                throw;
            }
            finally {
                pp.Paint -= Paint_SwapLabel;
            }
            Complete?.Invoke(this, new EventArgs());
            return;
        }



        public void Swap(Graphics G, Color pGraphicBackColor, List<Label> pLabelList, int pInterval)
        {
            GraphicRender = G;
            GraphicBackColor = pGraphicBackColor;
            labelList = pLabelList;

            Timer TSwap = new Timer();
            //  TSwap.Tag = arrLabelSwap[j];

            // arrLabelSwap[j].Visible = false;
            if(pInterval ==-1)
            {
                pInterval = 25;
            }
            CurrentarrLabelSwapIndex = 0;
            TSwap.Interval = pInterval ;
            TSwap.Tick += TSwap_Tic;
            TSwap.Enabled = true;



            return ;
        }

        int LoopCount = 0;
        int iYChange = 4;
        Boolean IsShowBackCard = false;
        int FirstY = 0;
        private void TSwap_Tic(object sender, EventArgs e)
        {
            Timer timerThis = (Timer)sender;

            Label label = labelList[CurrentarrLabelSwapIndex];
            LabelAttribute NewAttribute = (LabelAttribute)label.Tag;
            if (LoopCount == 0)
            {
                label.Visible = false;
            }

             Bitmap b = new Bitmap(label.Width, label.Height);
            label.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

            Image image = b;

            LoopCount++;


           
            Point[] NewDes = {
new Point(label.Left , label.Top ),   // destination for upper-left point of original
new Point(label.Left + label.Width, label.Top ),  // destination for upper-right point of original
new Point(label.Left , label.Top + label.Height)};  // destination for lower-left point of original


            if (IsShowBackCard)
            {
                NewDes[0].Y = label.Top + (iYChange * (15 - LoopCount));
             
                label.BackColor = NewAttribute.BackColor;
                label.ForeColor = NewAttribute.ForeColor;


            }
            else
            {


                NewDes[0].Y = label.Top + (iYChange * LoopCount);
            }

            if (LoopCount == 1)
            {
                FirstY = NewDes[0].Y;
            }
            NewDes[1].Y = NewDes[0].Y;
            if (IsShowBackCard)
            {
                NewDes[2].Y = label.Top + label.Height - (iYChange * (15 - LoopCount));
            }
            else
            {
                NewDes[2].Y = label.Top + label.Height - (iYChange * LoopCount);
            }
            
            GraphicRender.Clear(GraphicBackColor);
            GraphicRender.DrawImage(image, NewDes);
            if (NewDes[0].Y > NewDes[2].Y)
            {
                IsShowBackCard = true;

            }
            if (NewDes[0].Y <= FirstY)
            {
                if (IsShowBackCard)
                {
                    LoopCount = 0;

                    label.Visible = true;
                   
                    if (CurrentarrLabelSwapIndex < labelList.Count  - 1)
                    {
                        IsShowBackCard = false;
                        CurrentarrLabelSwapIndex++;

                    }
                    else
                    {
                        timerThis.Enabled = false;
                        Complete?.Invoke(this, new EventArgs());
                    }

                }
            }




        }

        public void DanceLabel(List<Label> pLabelList, int pTranstitionTime, int pNumberofLoop)
        {
            labelList = pLabelList;

            NumberofLoop = pNumberofLoop;
            TranstitionTime = pTranstitionTime;
            Timer Ti = new Timer();
            Ti.Interval = 200;
            Ti.Tick += Ti_TickV2;
            Ti.Enabled = true;

        }
        int iCountLoop = 0;
        int indexBtnMove = 0;
        int NumberofLoop = 1;
        int TranstitionTime = 200;
        private void Ti_TickV2(object sender, EventArgs e)
        {

            Label label = this.labelList[indexBtnMove];
            TransitionExtend transition = new TransitionExtend(new TransitionType_EaseInEaseOut(TranstitionTime));

            transition.add(label, "Top", label.Top - 20);
            transition.add(label, "BackColor", Color.Teal);


            TransitionExtend tBack = new TransitionExtend(new TransitionType_EaseInEaseOut(TranstitionTime));
            tBack.add(label, "Top", label.Top + 5);


            TransitionExtend tBack2 = new TransitionExtend(new TransitionType_EaseInEaseOut(450));
            tBack2.add(label, "Top", label.Top);


            transition.Childs = new List<TransitionExtend>();
            transition.Childs.Add(tBack);
            tBack.Childs = new List<TransitionExtend>();
            tBack.Childs.Add(tBack2);

            transition.run();
            indexBtnMove++;

            if (indexBtnMove >= this.labelList.Count)
            {
                iCountLoop++;
                indexBtnMove = 0;
                if (iCountLoop > NumberofLoop)
                {
                    Timer thisTimer = (Timer)sender;
                    thisTimer.Enabled = false;
                    Complete?.Invoke(this, new EventArgs());
                }
                return;
            }
        }
    
    }
}
