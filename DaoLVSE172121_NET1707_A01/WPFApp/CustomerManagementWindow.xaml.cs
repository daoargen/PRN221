using BusinessObject.DTO;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        private readonly ICustomerSer _cus;
        private List<CustomerDTO> customerDTOs;
        public CustomerManagementWindow()
        {
            InitializeComponent();
            _cus = new CustomerSer();
            this.Loaded += CustomerManagementWindow_Loaded;
        }


        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CustomerManagementWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            var customer = _cus.GetCustomerDTO();
            dtgCustomer.ItemsSource = customer;
            customerDTOs = customer;
        }
        private void dtgCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dtgCustomer.SelectedItem is CustomerDTO selectedCustomer)
            {
                txtId.Text = selectedCustomer.CustomerId.ToString();
                txtFullName.Text = selectedCustomer.CustomerFullName;
                txtTelephone.Text = selectedCustomer.Telephone;
                txtEmail1.Text = selectedCustomer.EmailAddress;
                txtDob.Text = selectedCustomer.CustomerBirthday?.ToString("yyyy-MM-dd");
                if (selectedCustomer.CustomerStatus == 1)
                {
                    txtStatus.Text = "True";
                }
                else
                {
                    txtStatus.Text = "False";
                }
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            _cus.DeleteCustomerById(System.Convert.ToInt32(txtId.Text));
            LoadCustomerData();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Closed += (s, args) => LoadCustomerData();
            addCustomerWindow.Show();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dtgCustomer.SelectedItem is CustomerDTO selectedCustomer)
            {
                UpdateCustomerWindow addCustomerWindow = new UpdateCustomerWindow()
                {
                    customer = selectedCustomer
                };
                addCustomerWindow.Closed += (s, args) => LoadCustomerData();
                addCustomerWindow.Show();
            }
        }

        private void txtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var searchText = txtSearch.Text;
            dtgCustomer.ItemsSource = customerDTOs
                .Where(x => (x.EmailAddress.Contains(searchText)) ||
                (x.CustomerFullName.Contains(searchText)) ||
                (x.Telephone.Contains(searchText)));
        }
    }
}
