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
    public partial class MusteriIstekleriForm : Form
    {
        public MusteriIstekleriForm()
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
            // Gorev form oluştur ve göster
            GorevForm gorevForm = new GorevForm();

            gorevForm.Show();
        }
    }
}
