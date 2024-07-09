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
        private DateTime startTime;
        private System.Windows.Forms.Timer timer;


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
            this.startTime = time;

            if (status.Equals("Open"))
            {
                this.status = "In Progress";
                // Log the start time into database
                LogActivity(adminUsername, customerId,subject, "Started task", time);

                // Update status to In Progress in the database
                UpdateRequestStatus(customerId);

                labelElapsedTimeText.Text = GetElapsedTime(time);

                // Initialize and start the timer to update elapsed time every second
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // 1 second
                timer.Tick += Timer_Tick;
                timer.Start();

                // Update UI
                button1.BackColor = redColor;
                button1.Text = this.status;
                labelStatusText.Text = this.status;

                
            }
            else if (this.status.Equals("In Progress"))// Finish the progress
            {
                // Log the end time into database
                this.status = "Closed";

                UpdateEndTime(customerId, time);
                // Update status to Closed in the database
                UpdateRequestStatus(customerId);

                UpdateAdminActivityLogActionToClosed(customerId);

                // Update UI
                button1.BackColor = grayColor; // Or any other color indicating closed state
                button1.Text = this.status;
                labelStatusText.Text = this.status;
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RequestForm_Load(object sender, EventArgs e)
        {
            // Fetch the start time from the database
            startTime = GetStartTime(customerId, subject);

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
                labelElapsedTimeText.Text = GetElapsedTime(startTime);

                // Initialize and start the timer to update elapsed time every second
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // 1 second
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
            {
                button1.BackColor = grayColor;
                button1.Text = "Closed";
                labelElapsedTimeText.Text = getTotalTime();
            }
        }




        private void UpdateEndTime(string customerId, DateTime endTime)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                            UPDATE adminactivitylog
                            SET EndTime = @endTime
                            WHERE CustomerId = @customerId AND Subject = @subject";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", this.subject);

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
        private void LogActivity(string adminUsername, string customerId,string subject, string action, DateTime startTime)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
            INSERT INTO AdminActivityLog (AdminUsername, CustomerId, Subject, Action, StartTime)
            VALUES (@adminUsername, @customerId, @subject, @action, @startTime)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@adminUsername", adminUsername);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);
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

        private void UpdateAdminActivityLogActionToClosed(string customerId)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                            UPDATE adminActivityLog
                            SET Action = 'Closed'
                            WHERE CustomerId = @customerId
                            AND Subject = @subject;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
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

        private DateTime GetStartTime(string customerId, string subject)
        {
            DateTime startTime = DateTime.MinValue; // Default value if not found
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                    SELECT CreatedDate
                    FROM supportRequest
                    WHERE CustomerId = @customerId AND Subject = @subject
                    LIMIT 1;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    connection.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        startTime = Convert.ToDateTime(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching start time: " + ex.Message);
                }
            }
            return startTime;
        }

        private string GetElapsedTime(DateTime startTime)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            return $"{elapsedTime.Hours}h {elapsedTime.Minutes}m {elapsedTime.Seconds}s";
        }

        private string getTotalTime()
        {
            DateTime startTime1 = DateTime.MinValue; // Default value if not found
            DateTime endTime = DateTime.MinValue; // Default value if not found

            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                    SELECT StartTime, EndTime
                    FROM adminactivitylog
                    WHERE CustomerId = @customerId
                    AND Subject = @subject
                    LIMIT 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                startTime1 = reader.GetDateTime(0);

                            if (!reader.IsDBNull(1))
                                endTime = reader.GetDateTime(1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching start time and end time: " + ex.Message);
                }
            }
            TimeSpan elapsedTime = endTime - startTime;
            return $"{elapsedTime.Hours}h {elapsedTime.Minutes}m {elapsedTime.Seconds}s";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (status.Equals("Closed"))
            {
                // Stop the timer
                timer.Stop();
            }
            else
            {
                // Update elapsed time label every second
                labelElapsedTimeText.Text = GetElapsedTime(startTime);
            }
        }

    }
}
