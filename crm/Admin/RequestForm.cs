using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

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
        private DateTime startTime;
        private System.Windows.Forms.Timer timer;
        private readonly Color greenYellowColor = Color.GreenYellow;
        private readonly Color redColor = Color.Red;
        private readonly Color grayColor = Color.Gray;

        public RequestForm(string customerId, string subject, string description, string status, string dateTime, string adminUsername)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.subject = subject;
            this.description = description;
            this.status = status;
            this.dateTime = dateTime;
            this.adminUsername = adminUsername;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            this.startTime = currentTime;

            if (status.Equals("Open"))
            {
                this.status = "In Progress";
                await LogActivityAsync(adminUsername, customerId, subject, "Started task", currentTime);
                await UpdateRequestStatusAsync(customerId, subject, this.status);

                labelElapsedTimeText.Text = GetElapsedTime(currentTime);
                timer.Start();
                UpdateUI(redColor, this.status);
            }
            else if (status.Equals("In Progress"))
            {
                this.status = "Closed";
                await UpdateEndTimeAsync(customerId, subject, currentTime);
                await UpdateRequestStatusAsync(customerId, subject, this.status);
                await UpdateAdminActivityLogActionToClosedAsync(customerId, subject);

                timer.Stop();
                UpdateUI(grayColor, this.status);
            }
        }

        private async void RequestForm_Load(object sender, EventArgs e)
        {
            startTime = GetStartTime(customerId, subject);
            DisplayRequestDetails();
            ConfigureFormBasedOnStatus();
            await LoadExistingNoteAsync(customerId, subject); // Notu yükleme işlemini burada çağırın
        }

        private void DisplayRequestDetails()
        {
            labelCustomerIDText.Text = customerId;
            labelSubjectText.Text = subject;
            labelStatusText.Text = status;
            labelDescriptionText.Text = description;
            labelDateText.Text = dateTime;
        }

        private void ConfigureFormBasedOnStatus()
        {
            switch (status)
            {
                case "Open":
                    UpdateUI(greenYellowColor, "Start Time");
                    break;
                case "In Progress":
                    UpdateUI(redColor, "In Progress");
                    labelElapsedTimeText.Text = GetElapsedTime(startTime);
                    timer.Start();
                    break;
                case "Closed":
                    UpdateUI(grayColor, "Closed");
                    labelElapsedTimeText.Text = GetTotalElapsedTime();
                    break;
            }
        }

        private void UpdateUI(Color buttonColor, string buttonText)
        {
            button1.BackColor = buttonColor;
            button1.Text = buttonText;
            labelStatusText.Text = status;
        }

        private async Task LogActivityAsync(string adminUsername, string customerId, string subject, string action, DateTime startTime)
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
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error logging activity: " + ex.Message);
                }
            }
        }

        private async Task UpdateRequestStatusAsync(string customerId, string subject, string status)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                UPDATE supportrequest
                SET Status = @status
                WHERE CustomerId = @customerId AND Subject = @subject;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }

        private async Task UpdateEndTimeAsync(string customerId, string subject, DateTime endTime)
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
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating end time: " + ex.Message);
                }
            }
        }

        private async Task UpdateAdminActivityLogActionToClosedAsync(string customerId, string subject)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                UPDATE adminActivityLog
                SET Action = 'Closed'
                WHERE CustomerId = @customerId AND Subject = @subject;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status: " + ex.Message);
                }
            }
        }

        private DateTime GetStartTime(string customerId, string subject)
        {
            DateTime startTime = DateTime.MinValue;
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

        private string GetTotalElapsedTime()
        {
            DateTime startTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                SELECT StartTime, EndTime
                FROM adminactivitylog
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
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            startTime = reader.GetDateTime(0);
                            if (!reader.IsDBNull(1))
                            {
                                endTime = reader.GetDateTime(1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching total elapsed time: " + ex.Message);
                }
            }

            if (endTime != DateTime.MinValue)
            {
                TimeSpan totalElapsedTime = endTime - startTime;
                return $"{totalElapsedTime.Hours}h {totalElapsedTime.Minutes}m {totalElapsedTime.Seconds}s";
            }
            return "N/A";
        }

        private async Task LoadExistingNoteAsync(string customerId, string subject)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                SELECT Note
                FROM notes
                WHERE CustomerId = @customerId AND Subject = @subject
                ORDER BY CreatedDate DESC
                LIMIT 1;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);

                try
                {
                    await connection.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    if (result != null && result != DBNull.Value)
                    {
                        noteTextBox.Text = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading existing note: " + ex.Message);
                }
            }
        }

        private async Task SaveNoteAsync(string customerId, string subject, string note)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                INSERT INTO notes (CustomerId, Subject, Note, CreatedDate)
                VALUES (@customerId, @subject, @note, @createdDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@subject", subject);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@createdDate", DateTime.Now);

                try
                {
                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving note: " + ex.Message);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelElapsedTimeText.Text = GetElapsedTime(startTime);
        }

        private async void updateNoteButton_Click(object sender, EventArgs e)
        {
            string noteText = noteTextBox.Text;
            if (string.IsNullOrWhiteSpace(noteText))
            {
                MessageBox.Show("Please enter a note.");
                return;
            }

            await SaveNoteAsync(customerId, subject, noteText);
        }
    }
}
