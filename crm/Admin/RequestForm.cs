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
    public partial class RequestForm : Form
    {
        private string customerId;
        private string subject;
        private string description;
        private string status;
        private string dateTime;
        private string adminUsername;
        private Color greenYellowColor = Color.GreenYellow;
        private Color redColor = Color.Red;
        private Color grayColor = Color.Gray;

        public RequestForm(string customerId, string subject, string description, string status, string dateTime,string adminUsername)
        {
            InitializeComponent();
            this.customerId = customerId    ;
            this.subject = subject;
            this.description = description;
            this.status = status;
            this.dateTime = dateTime;
            this.adminUsername = adminUsername;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            if (status.Equals("Open"))
            {
                this.status = "In Progress";
                // Log the start time into database
                LogActivity(adminUsername, customerId, "Started task", time);

                // Update status to In Progress in the database
                UpdateRequestStatus(customerId);

                // Update UI
                button1.BackColor = redColor;
                button1.Text = this.status;
                labelStatusText.Text = this.status;

                
            }
            else // Finish the progress
            {
                // Log the end time into database
                this.status = "Closed";

                UpdateEndTime(customerId, time);
                // Update status to Closed in the database
                UpdateRequestStatus(customerId);

                // Update UI
                button1.BackColor = grayColor; // Or any other color indicating closed state
                button1.Text = this.status;
                labelStatusText.Text = this.status;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RequestFormLoad(object sender, EventArgs e)
        {
            // Display the data passed from MusteriIstekleriForm
            labelCustomerIDText.Text = customerId;
            labelSubjectText.Text = subject;
            labelStatusText.Text = status;
            labelDescriptionText.Text = description;
            labelDateText.Text = dateTime;
            if (status.Equals("Open"))
            {
                button1.BackColor = greenYellowColor;
                button1.Text = "Start Time";
            }
                
            else if (status.Equals("In Progress"))
            {
                button1.BackColor = redColor;
                button1.Text = "In Progress";
            }
            else
            {
                button1.BackColor= grayColor;
                button1.Text = "Closed";
            }
            

        }

        private void UpdateEndTime(string customerId, DateTime endTime)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                            UPDATE adminactivitylog
                            SET EndTime = @endTime
                            WHERE CustomerId = @customerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@customerId", customerId);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating end time: " + ex.Message);
                }
            }
        }
        private void LogActivity(string adminUsername, string customerId, string action, DateTime startTime)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
            INSERT INTO AdminActivityLog (AdminUsername, CustomerId, Action, StartTime)
            VALUES (@adminUsername, @customerId, @action, @startTime)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@adminUsername", adminUsername);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@startTime", startTime);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error logging activity: " + ex.Message);
                }
            }
        }

        private void UpdateRequestStatus(string customerId)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                            UPDATE supportrequest
                            SET Status = @status
                            WHERE CustomerId = @customerId
                            AND Subject = @subject;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", this.status);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", this.subject);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }

    }
}
