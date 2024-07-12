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
            string query = "SELECT password, id FROM users WHERE username = @username AND usertype = @usertype";

            if (inputUserType.Equals("Customer")) query = @"SELECT u.Password AS Password, c.ID AS id 
                                                            FROM users u INNER JOIN customer c ON 
                                                            u.Username = @username AND u.UserType = @usertype 
                                                            AND u.Name = c.Name;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", inputUsername);
                cmd.Parameters.AddWithValue("@usertype", inputUserType);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPassword = reader["password"].ToString();
                        int customerId = Convert.ToInt32(reader["id"]);

                        if (storedPassword == inputPassword)
                        {
                            // Password matches
                            MessageBox.Show("Login successful!");

                            // Insert login record into the logins table
                            InsertLoginRecord(inputUsername, inputUserType, connectionString);

                            // Navigate to the appropriate form based on user type
                            if (inputUserType == "Admin")
                            {
                                // Open admin dashboard
                                AdminMainPage adminDashboard = new AdminMainPage(inputUsername);
                                adminDashboard.Show();
                            }
                            else if (inputUserType == "Customer")
                            {
                                // Open customer dashboard and pass customerId
                                CustomerDashboard customerDashboard = new CustomerDashboard(customerId);
                                customerDashboard.Show();
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

        private void InsertLoginRecord(string username, string usertype, string connectionString)
        {
            string insertQuery = "INSERT INTO logins (username, login_time, usertype) VALUES (@username, @login_time, @usertype)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@login_time", DateTime.Now);
                insertCmd.Parameters.AddWithValue("@usertype", usertype);

                try
                {
                    connection.Open();
                    insertCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting login record: " + ex.Message);
                }
            }
        }

    }
}
