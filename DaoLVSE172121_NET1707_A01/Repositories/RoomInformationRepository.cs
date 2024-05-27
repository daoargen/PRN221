using DataAccessObjects;
using DataAccessObjects.DAOs;

namespace Repositories
{
    public class RoomInformationRepository
    {
        public List<RoomInformation> GetRoomInformation() => RoomInformationDAO.GetRoomInformation();
        public void SaveRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.SaveRoomInformation(roomInformation);
        public void UpdateRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.UpdateRoomInformation(roomInformation);
        public void DeleteRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.DeleteRoomInformation(roomInformation);
        public RoomInformation GetRoomInformationById(int id) => RoomInformationDAO.GetRoomInformationById(id);
    }
}
