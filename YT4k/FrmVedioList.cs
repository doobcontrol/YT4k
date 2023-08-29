using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT4k
{
    public partial class FrmVedioList : Form
    {
        public FrmVedioList()
        {
            InitializeComponent();

            textBox1.Text = "https://www.youtube.com/@JDModel/videos";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

        }
    }
}
