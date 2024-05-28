using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class RoomInformationRepo : IRoomInformationRepo
    {
        public void AddRoomInformation(RoomInformation roomInformation)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                _content.RoomInformations.Add(roomInformation);
                _content.SaveChanges();
            }
        }

        public void DeleteRoomInformationById(int id)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                _content.RoomInformations.Remove(_content.RoomInformations.FirstOrDefault(x => x.RoomId == id));
                _content.SaveChanges();
            }
        }

        public List<RoomInformation> GetRoomInformation()
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.RoomInformations.ToList();
            }
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.RoomInformations.FirstOrDefault(x => x.RoomId == id);
            }
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                _content.RoomInformations.Update(roomInformation);
                _content.SaveChanges();
            }
        }
    }
}
