using MySql.Data.MySqlClient;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        
        private void MusterilerForm_Load(object sender, EventArgs e) {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;"; // Bağlantı dizesini kendinize göre düzenleyin.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM customer";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int yOffset = 30; // İlk satırın altına gelecek mesafe
                    int yMargin = customerID.Location.Y + 20;
                    while (reader.Read())
                    {
                        // Her satır için 5 tane Label oluşturup panelData'ya ekliyoruz.
                        AddRowToPanel(reader["ID"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString(), yOffset, yMargin);
                        yOffset += 30; // Bir sonraki satırın altına gelecek mesafe
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddRowToPanel(string id, string name, string email, string phone, string address, int yOffset, int yMargin)
        {
            // ID Label
            Label labelIdValue = new Label();
            labelIdValue.Text = id;
            labelIdValue.AutoSize = true;
            labelIdValue.Location = new System.Drawing.Point(0, yOffset + yMargin);
            labelIdValue.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(labelIdValue);

            // Name Label
            Label labelNameValue = new Label();
            labelNameValue.Text = name;
            labelNameValue.AutoSize = true;
            labelNameValue.Location = new System.Drawing.Point(150, yOffset + yMargin);
            labelNameValue.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(labelNameValue);

            // Email Label
            Label labelEmailValue = new Label();
            labelEmailValue.Text = email;
            labelEmailValue.AutoSize = true;
            labelEmailValue.Location = new System.Drawing.Point(350, yOffset + yMargin);
            labelEmailValue.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(labelEmailValue);

            // Phone Label
            Label labelPhoneValue = new Label();
            labelPhoneValue.Text = phone;
            labelPhoneValue.AutoSize = true;
            labelPhoneValue.Location = new System.Drawing.Point(550, yOffset + yMargin);
            labelPhoneValue.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(labelPhoneValue);

            // Address Label
            Label labelAddressValue = new Label();
            labelAddressValue.Text = address;
            labelAddressValue.AutoSize = true;
            labelAddressValue.Location = new System.Drawing.Point(750, yOffset + yMargin);
            labelAddressValue.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(labelAddressValue);
        }

        private void customerPhone_Click(object sender, EventArgs e)
        {

        }
    }

}
