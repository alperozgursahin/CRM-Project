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

namespace crm.Customer
{
    public partial class CustomerCreateRequest : Form
    {
        private int customerId;
        public CustomerCreateRequest(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void buttonSubmitRequest_Click(object sender, EventArgs e)
        {
            string subject = textSubject.Text;
            string description = textDescription.Text;
            string status = "Open"; // Default status
            DateTime createdDate = DateTime.Now;

            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = "INSERT INTO supportrequest (CustomerId, Subject, Description, Status, CreatedDate) VALUES (@CustomerId, @Subject, @Description, @Status, @CreatedDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Subject", subject);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@CreatedDate", createdDate);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Support request submitted successfully.");
                    // Optionally, clear the input fields
                    textSubject.Clear();
                    textDescription.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void CustomerCreateRequest_Load(object sender, EventArgs e)
        {

        }
    }
}
