namespace crm
{
    public partial class Form1 : Form
    {
        private string username;
        public Form1(string username)
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

        private void Form1_Load(object sender, EventArgs e)
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
