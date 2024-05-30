using BusinessObject;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private readonly ICustomerSer _cus;
        public AddCustomerWindow()
        {
            InitializeComponent();
            _cus = new CustomerSer();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtTelephone.Text;
            //customer.CustomerBirthday = dpDob.Text;
            customer.EmailAddress = txtEmail.Text;
            customer.CustomerStatus = 1;
            _cus.AddCustomer(customer);
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
