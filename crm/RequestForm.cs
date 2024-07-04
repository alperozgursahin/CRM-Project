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
    public partial class RequestForm : Form
    {
        private string customerId;
        private string subject;
        private string description;
        private string status;
        private string dateTime;
        private Color defaultColor = Color.GreenYellow;
        private Color newColor = Color.Red;

        public RequestForm(string id, string subject, string description, string status, string dateTime)
        {
            InitializeComponent();
            this.customerId = id;
            this.subject = subject;
            this.description = description;
            this.status = status;
            this.dateTime = dateTime;
            
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

        private void RequestFormLoad(object sender, EventArgs e)
        {
            // Display the data passed from MusteriIstekleriForm
            labelSubjectText.Text = subject;
            labelDescriptionText.Text = description;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Detay_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
