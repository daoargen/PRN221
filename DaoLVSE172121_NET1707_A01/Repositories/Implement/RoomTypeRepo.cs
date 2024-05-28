using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class RoomTypeRepo : IRoomTypeRepo
    {
        public List<RoomType> GetRoomTypes()
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.RoomTypes.ToList();
            }
        }
    }
}
