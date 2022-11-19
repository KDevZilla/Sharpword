using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpWord
{
    /*
     Credit
     https://stackoverflow.com/questions/42627293/label-with-smooth-rounded-corners
     */
    public class RoundLabel:Label 
    {
        [Browsable(true)]
        public Color _BackColor { get { return __BackColor; }
            set {
                 __BackColor = value;
                 this.Invalidate();
               // this.BackColor = value;
            }
        }
        private Color __BackColor;

       
        public RoundLabel ()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;

        }
        public void MakeRound()
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path = _getRoundRectangle(this.ClientRectangle);
            this.Region = new Region(path);
        }
        private void RoundLabel_Resize(object sender, System.EventArgs e)
        {


        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = _getRoundRectangle(this.ClientRectangle))
            {


                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(_BackColor))
                    e.Graphics.FillPath(brush, graphicsPath);
                using (var pen = new Pen(_BackColor, 1.0f))
                    e.Graphics.DrawPath(pen, graphicsPath);
                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }
        

        public GraphicsPath _getRoundRectangle(Rectangle rectangle)
        {
            int cornerRadius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
