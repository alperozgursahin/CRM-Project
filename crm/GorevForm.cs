using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class GorevForm : Form
    {

        private Color defaultColor = Color.GreenYellow;
        private Color newColor = Color.Red;

        public GorevForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == defaultColor)
            {
                button1.BackColor = newColor;
            }
            else
            {
                button1.BackColor = defaultColor;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
