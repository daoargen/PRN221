using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminNarWindow.xaml
    /// </summary>
    public partial class AdminNarWindow : Window
    {
        public bool isAdmin { get; set; }
        public AdminNarWindow()
        {

            InitializeComponent();
        }

        private void btnCustomerInfomationManagement_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            CustomerManagementWindow customerManagementWindow = new CustomerManagementWindow();
            customerManagementWindow.Closed += (s, args) => Show(); // Show login form when management form is closed
            customerManagementWindow.Show();
        }

        private void btnRoomInformationInfomationManagement_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            RoomInformationManagementWindow roomInformationManagementWindow = new RoomInformationManagementWindow();
            roomInformationManagementWindow.Closed += (s, args) => Show(); // Show login form when management form is closed
            roomInformationManagementWindow.Show();
        }
    }
}
