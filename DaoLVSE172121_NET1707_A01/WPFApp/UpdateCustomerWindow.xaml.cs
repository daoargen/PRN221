using BusinessObject;
using BusinessObject.DTO;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        public CustomerDTO customer { get; set; }
        private ICustomerSer _cus;
        public UpdateCustomerWindow()
        {
            InitializeComponent();
            _cus = new CustomerSer();
            this.Loaded += UpdateCustomerWindow_Loaded;
        }

        private void UpdateCustomerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            txtFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = customer.Telephone;
            txtEmail.Text = customer.EmailAddress;
            txtDob.Text = customer.CustomerBirthday?.ToString("yyyy-MM-dd");
            if (customer.CustomerStatus == 1)
            {
                txtStatus.Text = "True";
            }
            else
            {
                txtStatus.Text = "False";
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtTelephone.Text;
            //customer.CustomerBirthday = dpDob.Text;
            customer.EmailAddress = txtEmail.Text;
            customer.CustomerStatus = 1;
            _cus.UpdateCustomer(customer);
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
