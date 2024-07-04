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
    public partial class CustomerRequest : Form
    {
        public CustomerRequest()
        {
            InitializeComponent();
        }

        private void MusteriIstekleriForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=crm_database;user=root;password=1234";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM supportrequest";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string subject = row.Cells["Subject"].Value.ToString();
                string description = row.Cells["Description"].Value.ToString();

                // Pass the data to GorevForm
                RequestForm gorevForm = new RequestForm(subject, description);
                gorevForm.Show();
            }
        }

    }
}
