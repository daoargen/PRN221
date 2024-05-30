using Microsoft.Extensions.Configuration;
using Services.Implement;
using Services.Interface;
using System.IO;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerSer _cus;
        private string adminEmail;
        private string adminPassword;
        public MainWindow()
        {
            _cus = new CustomerSer();
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (AllowLogin())
            {

                if (LoginWithAdminAccount(txtEmail.Text.Trim(), txtPassword.Password.Trim()))
                {
                    Hide();

                    AdminNarWindow adminNarWindow = new AdminNarWindow
                    {
                        isAdmin = true,
                    };
                    adminNarWindow.Closed += (s, args) => Show(); // Show login form when management form is closed

                    adminNarWindow.Show();
                }
                else
                {
                    var validate = _cus.ValidCustomer(txtEmail.Text.Trim(), txtPassword.Password.Trim());
                    if (validate)
                    {
                        Hide();

                        UserNarWindow userNarWindow = new UserNarWindow
                        {
                            customer = _cus.GetCustomerByMail(txtEmail.Text.Trim()),
                        };
                        userNarWindow.Closed += (s, args) => Show(); // Show login form when management form is closed

                        userNarWindow.Show();

                    }
                    else
                    {
                        MessageBox.Show("You have no permision to this system!", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

            }
        }

        private bool AllowLogin()
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Please enter your password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            var configFilePath = System.IO.Path.Combine(projectDirectory, "appsettings.json");

            var config = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile(configFilePath, optional: true, reloadOnChange: true)
                .Build();
            /*var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();*/
            IConfigurationSection section = config.GetSection("AdminAccount");

            adminEmail = section["Email"];
            adminPassword = section["Password"];

        }

        private bool LoginWithAdminAccount(string email, string password)
        {
            if (email == adminEmail && password == adminPassword)
            {
                return true;
            }
            return false;
        }

    }
}