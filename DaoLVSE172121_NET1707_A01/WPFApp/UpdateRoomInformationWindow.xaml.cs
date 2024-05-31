using BusinessObject;
using BusinessObject.DTO;
using Services.Implement;
using Services.Interface;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateRoomInformationWindow.xaml
    /// </summary>
    public partial class UpdateRoomInformationWindow : Window
    {
        private readonly IRoomInformationSer _room;
        public RoomInformationDTO roomInformationDTO { get; set; }
        public UpdateRoomInformationWindow()
        {
            InitializeComponent();
            _room = new RoomInformationSer();
            this.Loaded += UpdateRoomInformationWindow_Loaded;
        }

        private void UpdateRoomInformationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loadUpdateRoominformation();
        }

        private void loadUpdateRoominformation()
        {
            txtRoomDetailDescription.Text = roomInformationDTO.RoomDetailDescription;
            txtRoomMaxCapacity.Text = roomInformationDTO.RoomMaxCapacity.ToString();
            txtRoomNumber.Text = roomInformationDTO.RoomNumber.ToString();
            txtRoomPricePerDay.Text = roomInformationDTO.RoomPricePerDay.ToString();
            txtRoomTypeId.Text = roomInformationDTO.RoomTypeId.ToString();
            txtStatus.Text = roomInformationDTO.RoomStatus.ToString();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation roomInformation = new RoomInformation();
            roomInformation.RoomDetailDescription = txtRoomDetailDescription.Text;
            roomInformation.RoomMaxCapacity = System.Convert.ToInt32(txtRoomMaxCapacity.Text);
            roomInformation.RoomNumber = txtRoomNumber.Text;
            roomInformation.RoomPricePerDay = System.Convert.ToDecimal(txtRoomPricePerDay.Text);
            roomInformation.RoomTypeId = System.Convert.ToInt32(txtRoomTypeId.Text);
            roomInformation.RoomStatus = 1;
            roomInformation.RoomId = roomInformationDTO.RoomId;
            _room.UpdateRoomInformation(roomInformation);
            Close();
        }
    }
}
