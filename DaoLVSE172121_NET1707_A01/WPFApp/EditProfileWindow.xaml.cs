using BusinessObject;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private readonly ICustomerSer _cus;
        public Customer currentCustomer { get; set; }
        public EditProfileWindow()
        {
            InitializeComponent();
            _cus = new CustomerSer();
            this.Loaded += EditProfileWindow_Loaded;
        }

        private void EditProfileWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadEditUser();
        }

        private void loadEditUser()
        {
            txtFullName.Text = currentCustomer.CustomerFullName;
            txtTelephone.Text = currentCustomer.Telephone;
            txtEmail.Text = currentCustomer.EmailAddress;
            txtDob.Text = currentCustomer.CustomerBirthday?.ToString("yyyy-MM-dd");
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerId = currentCustomer.CustomerId;
            customer.CustomerFullName = txtFullName.Text;
            customer.Telephone = txtTelephone.Text;
            //customer.CustomerBirthday = dpDob.Text;
            customer.EmailAddress = txtEmail.Text;
            customer.CustomerStatus = 1;
            _cus.UpdateCustomer(customer);
            loadEditUser();
        }
    }
}
