using BusinessObject;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UserNarWindow.xaml
    /// </summary>
    public partial class UserNarWindow : Window
    {
        public Customer customer { get; set; }
        public UserNarWindow()
        {
            InitializeComponent();
        }

        private void btnCustomerInfomationManagement_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            EditProfileWindow editProfileWindow = new EditProfileWindow()
            {
                currentCustomer = customer
            };
            editProfileWindow.Closed += (s, args) => Show();
            editProfileWindow.Show();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            WiewBookingHistoryWindow wiewBookingHistoryWindow = new WiewBookingHistoryWindow()
            {
                currentCustomer = customer
            };
            wiewBookingHistoryWindow.Closed += (s, args) => Show();
            wiewBookingHistoryWindow.Show();
        }
    }
}
