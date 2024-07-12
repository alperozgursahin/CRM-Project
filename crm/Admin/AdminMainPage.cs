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
            // Yeni bir Form2 nesnesi olu�tur
            Customers customers = new Customers();

            // Yeni formu g�ster
            customers.Show();
        }

        private void AdminMainPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni bir Form2 nesnesi olu�tur
            CustomerRequest customerRequest = new CustomerRequest(username);

            // Yeni formu g�ster
            customerRequest.Show();
        }
    }
}
