using crm.Customer;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace crm
{
    public partial class CustomerDashboard : Form
    {
        private int customerId;
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
                        // Veritabanından okunan değerlerin null olup olmadığını kontrol ediyoruz
                        string id = reader["Id"].ToString();
                        string subject = reader["Subject"] as string ?? "";
                        string description = reader["Description"] as string ?? "";
                        string status = reader["Status"] as string ?? "";
                        DateTime createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        string createdDateString = createdDate.ToString("yyyy-MM-dd HH:mm:ss");

                        // Her satır için 5 tane Label ve 1 Buton oluşturup panelData'ya ekliyoruz.
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
            // Parametrelerin null olup olmadığını kontrol ediyoruz
            id ??= "";
            subject ??= "";
            description ??= "";
            status ??= "";
            dateTime ??= "";

            AddLabelToPanel(id, labelID.Location.X, yOffset, yMargin);
            AddLabelToPanel(subject, labelSubject.Location.X, yOffset, yMargin, isSubject: true);
            AddLabelToPanel(description, labelDescription.Location.X, yOffset, yMargin, isDescription: true);
            AddLabelToPanel(status, labelStatus.Location.X, yOffset, yMargin);
            AddLabelToPanel(dateTime, labelDate.Location.X, yOffset, yMargin);
        }

        private void AddLabelToPanel(string text, int xPosition, int yOffset, int yMargin, bool isDescription = false, bool isSubject = false)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            if (isDescription) label.MaximumSize = new System.Drawing.Size(250, 30);
            if (isSubject) label.MaximumSize = new System.Drawing.Size(125, 30);
            label.AutoEllipsis = true;
            label.Location = new System.Drawing.Point(xPosition, yOffset + yMargin);
            label.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(label);
        }

        private void buttonCreateNewRequest_Click(object sender, EventArgs e)
        {
            CustomerCreateRequest createRequest = new CustomerCreateRequest(customerId);
            createRequest.Show();
        }
    }
}
