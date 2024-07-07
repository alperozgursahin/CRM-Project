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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            cmbUserType.SelectedIndex = 0;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;
            string userType = cmbUserType.SelectedItem.ToString();

            // Bu kısımda kullanıcı adı ve şifreyi kontrol edin.
            // Burada sabit bir kontrol yapıyoruz, fakat veritabanı ile de entegre edebilirsiniz.

            if (userType == "Admin" && username == "admin" && password == "admin123")
            {
                MessageBox.Show("Admin girişi başarılı!", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                form1.Show();
            }
            else if (userType == "Customer" && username == "customer" && password == "customer123")
            {
                MessageBox.Show("Customer girişi başarılı!", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Customer paneline yönlendirme
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
