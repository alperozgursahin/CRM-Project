using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace crm
{
    public partial class CustomerRequest : Form
    {
        public CustomerRequest()
        {
            InitializeComponent();
        }

        private void CustomerRequest_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=crm_database;uid=root;pwd=1234;";
            string query = "SELECT * FROM supportrequest";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int yOffset = 30; // İlk satırın altına gelecek mesafe
                    int yMargin = labelID.Location.Y + 20;

                    while (reader.Read())
                    {
                        // CreatedDate sütununu DateTime olarak okuyup string'e dönüştürüyoruz
                        DateTime createdDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                        string createdDateString = createdDate.ToString("yyyy-MM-dd HH:mm:ss");

                        // Her satır için 5 tane Label ve 1 Buton oluşturup panelData'ya ekliyoruz.
                        AddRowToPanel(reader["Id"].ToString(),
                                      reader["CustomerId"].ToString(),
                                      reader["Subject"].ToString(),
                                      reader["Description"].ToString(),
                                      reader["Status"].ToString(),
                                      createdDateString,
                                      yOffset, yMargin);
                        yOffset += 40; // Bir sonraki satırın altına gelecek mesafe
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddRowToPanel(string id, string customerId, string subject, string description, string status, string dateTime, int yOffset, int yMargin)
        {
            AddLabelToPanel(id, labelID.Location.X, yOffset, yMargin);
            AddLabelToPanel(customerId, labelCustomerID.Location.X, yOffset, yMargin);
            AddLabelToPanel(subject, labelSubject.Location.X, yOffset, yMargin, isSubject: true);
            AddLabelToPanel(description, labelDescription.Location.X, yOffset, yMargin, isDescription: true);
            AddLabelToPanel(status, labelStatus.Location.X, yOffset, yMargin);
            AddLabelToPanel(dateTime, labelDate.Location.X, yOffset, yMargin);

            // Buton ekleme
            AddButtonToPanel("Review", labelDate.Location.X + 175, yOffset, yMargin, id, subject, description, status, dateTime); // Butonun yerleşimini ayarlayın
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

        private void AddButtonToPanel(string text, int xPosition, int yOffset, int yMargin, string id, string subject, string description, string status, string dateTime)
        {
            Button button = new Button();
            button.Text = text;
            button.AutoSize = true;
            button.Location = new System.Drawing.Point(xPosition, yOffset + yMargin - 8);
            button.Anchor = AnchorStyles.Top;
            panelData.Controls.Add(button);

            // Buton tıklama olayı
            button.Click += (sender, e) =>
            {
                // RequestForm'u oluşturup parametreleri gönderme
                RequestForm requestForm = new RequestForm(id, subject, description, status, dateTime);
                requestForm.Show();
            };
        }
    }
}
