using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            string inputUsername = textUsername.Text;
            string inputPassword = textPassword.Text;
            string inputUserType = cmbUserType.SelectedItem.ToString();

            // Connection string to your database
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";

            // Parameterized query to prevent SQL injection
            string query = "SELECT password FROM users WHERE username = @username AND role = @role";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", inputUsername);
                cmd.Parameters.AddWithValue("@role", inputUserType);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPassword = reader["password"].ToString();

                        if (storedPassword == inputPassword)
                        {
                            // Password matches
                            MessageBox.Show("Login successful!");

                            // Navigate to the appropriate form based on user type
                            if (inputUserType == "Admin")
                            {
                                // Open admin dashboard
                                Form1 adminDashboard = new Form1();
                                adminDashboard.Show();
                            }
                            else if (inputUserType == "Customer")
                            {
                                // Open customer dashboard
                                //CustomerDashboard customerDashboard = new CustomerDashboard();
                                //customerDashboard.Show();
                            }

                            this.Hide(); // Hide the login form
                        }
                        else
                        {
                            // Password does not match
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                    else
                    {
                        // No such user found
                        MessageBox.Show("Invalid username or password.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
