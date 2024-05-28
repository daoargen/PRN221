using BusinessObject;

namespace Repositories.Interface
{
    public interface IRoomInformationRepo
    {
        public List<RoomInformation> GetRoomInformation();
        public void AddRoomInformation(RoomInformation roomInformation);
        public void DeleteRoomInformationById(int id);
        public void UpdateRoomInformation(RoomInformation roomInformation);
        public RoomInformation GetRoomInformationById(int id);
    }
}
