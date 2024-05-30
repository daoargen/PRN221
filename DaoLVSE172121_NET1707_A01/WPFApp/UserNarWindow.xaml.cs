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
    }
}
