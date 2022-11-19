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
    public partial class frmShowProblemWIthRoundLabel : Form
    {
        public frmShowProblemWIthRoundLabel()
        {
            InitializeComponent();
        }

        private void frmShowProblemWIthRoundLabel_Load(object sender, EventArgs e)
        {
            this.roundLabel1._BackColor = Color.Aquamarine;
            this.roundLabel2._BackColor = Color.Aquamarine;

        }
    }
}
