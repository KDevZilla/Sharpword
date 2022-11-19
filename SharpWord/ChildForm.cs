using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpWord.UI;

namespace SharpWord
{
     // BaseFormMiddle2 explained below
    public  class ChildForm:System.Windows.Forms.Form 
    {
        public MainUI mainUI = null;
        public ChildForm():base()
        {
           // mainUI = pMainUI;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //RenderTheme();
        }

        public virtual void RenderTheme()
        {
            throw new Exception("Need to implement");
        }
    }

   

}
