using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class RoomInformationRepo : IRoomInformationRepo
    {
        public void AddRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.RoomInformations.Add(roomInformation);
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void DeleteRoomInformationById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.RoomInformations.Remove(_content.RoomInformations.FirstOrDefault(x => x.RoomId == id));
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public List<RoomInformation> GetRoomInformation()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.RoomInformations.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.RoomInformations.FirstOrDefault(x => x.RoomId == id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.RoomInformations.Update(roomInformation);
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}
