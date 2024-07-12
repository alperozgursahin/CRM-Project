namespace crm
{
    public partial class AdminMainPage : Form
    {
        private string username;
        public AdminMainPage(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Yeni bir Form2 nesnesi oluþtur
            Customers customers = new Customers();

            // Yeni formu göster
            customers.Show();
        }

        private void AdminMainPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni bir Form2 nesnesi oluþtur
            CustomerRequest customerRequest = new CustomerRequest(username);

            // Yeni formu göster
            customerRequest.Show();
        }
    }
}
