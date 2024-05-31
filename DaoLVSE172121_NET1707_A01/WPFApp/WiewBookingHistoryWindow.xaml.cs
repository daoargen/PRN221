using BusinessObject;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for WiewBookingHistoryWindow.xaml
    /// </summary>
    public partial class WiewBookingHistoryWindow : Window
    {
        private readonly ICustomerSer _cus;
        public Customer currentCustomer { get; set; }
        public WiewBookingHistoryWindow()
        {
            InitializeComponent();
            _cus = new CustomerSer();
            this.Loaded += WiewBookingHistoryWindow_Loaded;
        }

        private void WiewBookingHistoryWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadHistoryData();
        }

        private void loadHistoryData()
        {
            dtgHistory.ItemsSource = _cus.GetBookingHistories(currentCustomer.CustomerId);
        }
    }
}
