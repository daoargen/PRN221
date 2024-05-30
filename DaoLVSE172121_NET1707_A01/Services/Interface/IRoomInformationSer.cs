using BusinessObject;
using BusinessObject.DTO;

namespace Services.Interface
{
    public interface IRoomInformationSer
    {
        public List<RoomInformation> GetRoomInformation();
        public void AddRoomInformation(RoomInformation roomInformation);
        public void DeleteRoomInformationById(int id);
        public void UpdateRoomInformation(RoomInformation roomInformation);
        public RoomInformation GetRoomInformationById(int id);
        public List<RoomInformationDTO> GetRoomInformationDTO();
    }
}
