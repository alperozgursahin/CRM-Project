using crm.Customer;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace crm
{
    public partial class CustomerDashboard : Form
    {
        private readonly int customerId;

        public CustomerDashboard(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = @"
                SELECT Id, Subject, Description, Status, CreatedDate
                FROM supportrequest
                WHERE CustomerId = @customerId
                ORDER BY CreatedDate DESC";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int yOffset = 30; // İlk satırın altına gelecek mesafe
                    int yMargin = labelID.Location.Y + 20;

                    while (reader.Read())
                    {
                        string id = reader["Id"]?.ToString() ?? string.Empty;
                        string subject = reader["Subject"]?.ToString() ?? string.Empty;
                        string description = reader["Description"]?.ToString() ?? string.Empty;
                        string status = reader["Status"]?.ToString() ?? string.Empty;
                        DateTime createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        string createdDateString = createdDate.ToString("yyyy-MM-dd HH:mm:ss");

                        AddRowToPanel(id, subject, description, status, createdDateString, yOffset, yMargin);
                        yOffset += 40; // Bir sonraki satırın altına gelecek mesafe
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddRowToPanel(string id, string subject, string description, string status, string dateTime, int yOffset, int yMargin)
        {
            AddLabelToPanel(id, labelID.Location.X, yOffset, yMargin);
            AddLabelToPanel(subject, labelSubject.Location.X, yOffset, yMargin, isSubject: true);
            AddLabelToPanel(description, labelDescription.Location.X, yOffset, yMargin, isDescription: true);
            AddLabelToPanel(status, labelStatus.Location.X, yOffset, yMargin);
            AddLabelToPanel(dateTime, labelDate.Location.X, yOffset, yMargin);
        }

        private void AddLabelToPanel(string text, int xPosition, int yOffset, int yMargin, bool isDescription = false, bool isSubject = false)
        {
            Label label = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new System.Drawing.Point(xPosition, yOffset + yMargin),
                Anchor = AnchorStyles.Top
            };

            if (isDescription)
                label.MaximumSize = new System.Drawing.Size(250, 30);

            if (isSubject)
                label.MaximumSize = new System.Drawing.Size(125, 30);

            label.AutoEllipsis = true;
            panelData.Controls.Add(label);
        }

        private void buttonCreateNewRequest_Click(object sender, EventArgs e)
        {
            CustomerCreateRequest createRequest = new CustomerCreateRequest(customerId);
            createRequest.Show();
        }

    }
}
