namespace crm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            CustomerRequest customerRequest = new CustomerRequest();

            // Yeni formu g�ster
            customerRequest.Show();
        }
    }
}
