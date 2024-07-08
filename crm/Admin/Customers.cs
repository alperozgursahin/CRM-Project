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
        
        private void Customers_Load(object sender, EventArgs e) {
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
                        yOffset += 40; // Bir sonraki satırın altına gelecek mesafe
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
            AddLabelToPanel(id, 0, yOffset, yMargin);
            AddLabelToPanel(name, 150, yOffset, yMargin);
            AddLabelToPanel(email, 350, yOffset, yMargin);
            AddLabelToPanel(phone, 550, yOffset, yMargin);
            AddLabelToPanel(address, 750, yOffset, yMargin);
        }

        private void AddLabelToPanel(string text, int xPosition, int yOffset, int yMargin)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = false;
            label.AutoEllipsis = true;
            label.Location = new System.Drawing.Point(xPosition, yOffset + yMargin);
            label.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(label);
        }

        
    }

}
