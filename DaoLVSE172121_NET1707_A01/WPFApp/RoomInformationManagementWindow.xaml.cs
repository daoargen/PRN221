using BusinessObject.DTO;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RoomInformationManagementWindow.xaml
    /// </summary>
    public partial class RoomInformationManagementWindow : Window
    {
        private readonly IRoomInformationSer _room;
        private List<RoomInformationDTO> roomInformationDTOs;

        public RoomInformationManagementWindow()
        {
            InitializeComponent();
            _room = new RoomInformationSer();
            this.Loaded += RoomInformationManagementWindow_Loaded;
        }

        private void RoomInformationManagementWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomInformationData();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadRoomInformationData()
        {
            List<RoomInformationDTO> roomInformation = _room.GetRoomInformationDTO();
            dtgRoomInformation.ItemsSource = roomInformation;
            roomInformationDTOs = roomInformation;
        }

        private void txtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var searchText = txtSearch.Text;
            dtgRoomInformation.ItemsSource = roomInformationDTOs
                .Where(x => (x.RoomNumber.Contains(searchText)) ||
                (x.RoomDetailDescription.Contains(searchText))).ToList();
        }

        private void dtgRoomInformation_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dtgRoomInformation.SelectedItem is RoomInformationDTO selectedRoom)
            {
                txtId.Text = selectedRoom.RoomId.ToString();
                txtRoomNumber.Text = selectedRoom.RoomNumber.ToString();
                txtRoomDetailDescription.Text = selectedRoom.RoomDetailDescription.ToString();
                txtRoomMaxCapacity.Text = selectedRoom.RoomMaxCapacity.ToString();
                txtRoomTypeId.Text = selectedRoom.RoomTypeId.ToString();
                txtStatus.Text = selectedRoom.RoomStatus.ToString();
                txtRoomPricePerDay.Text = selectedRoom.RoomPricePerDay.ToString();
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRoomInformationWindow addRoomInformationWindow = new AddRoomInformationWindow();
            addRoomInformationWindow.Closed += (s, args) => LoadRoomInformationData();
            addRoomInformationWindow.Show();
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            _room.DeleteRoomInformationById(System.Convert.ToInt32(txtId.Text));
            LoadRoomInformationData();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dtgRoomInformation.SelectedItem is RoomInformationDTO selectedRoom)
            {
                UpdateRoomInformationWindow updateRoomInformationWindow = new UpdateRoomInformationWindow()
                {
                    roomInformationDTO = selectedRoom
                };
                updateRoomInformationWindow.Closed += (s, args) => LoadRoomInformationData();
                updateRoomInformationWindow.Show();
            }
        }
    }
}
