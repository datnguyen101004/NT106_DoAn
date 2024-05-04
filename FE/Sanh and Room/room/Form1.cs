using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace room
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roundbutton2_Click(object sender, EventArgs e)
        {
            In4Panel.Visible = true;
            roundbutton1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundbutton1_Click(object sender, EventArgs e)
        {
            In4Panel.Visible = true;
            roundbutton1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            In4Panel.Visible=false;
            roundbutton1.Enabled = true;
            roundbutton2.Enabled = true;
        }
    }
}
