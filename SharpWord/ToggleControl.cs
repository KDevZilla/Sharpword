using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpWord
{
    //Credit::https://stackoverflow.com/questions/38431674/toggle-switch-control-in-windows-forms

    class ToggleControl : CheckBox
    {
        public ToggleControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            Padding = new Padding(6);
            this.CheckedChanged += ToggleControl_CheckedChanged;
          //  SetStyle ( ControlStyles.OptimizedDoubleBuffer && ControlStyles. )
        }
        int iCount = 0;
        int iCountMax = 5;
        private void ReDrawn()
        {
            this.Invalidate();
            iCount++;
            if(iCount >=iCountMax)
            {
                iCount = 0;
                System.Threading.Thread.Sleep(1);
            }
            
            Application.DoEvents();
        }
        private void ToggleControl_CheckedChanged(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            int r = 0 ;
            r = Height - 1;
            int i = 0;
            int iXBegin = 0;
            int iXEnd = 0;


            iXBegin = 0;
            iXEnd = Width - r - 1;
            if(this.Checked )
            {
                for(i=iXBegin;i<=iXEnd;i+=1)
                {
                    CurrentX = i;
                    ReDrawn();
                }
            }
            else
            {
                for(i=iXEnd;i>=iXBegin;i-=1)
                {
                    CurrentX = i;
                    ReDrawn();
                }
            }
          
        }
        int CurrentX = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
        
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                //var r = this.Height * 2;

                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();

                Color cCheckedTube = Color.FromArgb(141, 185, 244);
                Color cUnCheckedTube = Color.FromArgb(189, 193, 198);
                Brush BrTube = new SolidBrush(cCheckedTube);
                if (Checked)
                {
                    BrTube = new SolidBrush(cCheckedTube);
                }
                else
                {
                    BrTube = new SolidBrush(cUnCheckedTube);
                }

                Color cCheckedCircle = Color.FromArgb(26, 115, 232);
                Color cUnCheckCircle = Color.White;

                Brush Br = new SolidBrush(cCheckedCircle);
                if (Checked)
                {
                    Br = new SolidBrush(cCheckedCircle);
                }
                else
                {
                    Br = new SolidBrush(Color.DarkGray );
                }

                e.Graphics.FillPath(BrTube , path);
                r = Height - 1;

                var rect = new Rectangle ();

                rect = new Rectangle(CurrentX, 0, r, r);


                e.Graphics.FillEllipse(Br, rect);
            }
        }
    
    }
}
