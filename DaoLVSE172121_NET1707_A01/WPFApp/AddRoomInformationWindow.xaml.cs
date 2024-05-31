using BusinessObject;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddRoomInformationWindow.xaml
    /// </summary>
    public partial class AddRoomInformationWindow : Window
    {
        private readonly IRoomInformationSer _room;
        public AddRoomInformationWindow()
        {
            InitializeComponent();
            _room = new RoomInformationSer();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation roomInformation = new RoomInformation();
            roomInformation.RoomNumber = txtRoomNumber.Text;
            roomInformation.RoomDetailDescription = txtRoomDetailDescription.Text;
            roomInformation.RoomMaxCapacity = System.Convert.ToInt32(txtRoomMaxCapacity.Text);
            roomInformation.RoomTypeId = System.Convert.ToInt32(txtRoomTypeId.Text);
            roomInformation.RoomStatus = 1;
            roomInformation.RoomPricePerDay = System.Convert.ToInt32(txtRoomPricePerDay.Text);
            _room.AddRoomInformation(roomInformation);
            Close();
        }
    }
}
