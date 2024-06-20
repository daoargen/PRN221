using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class RoomTypeRepo : IRoomTypeRepo
    {
        public async Task<List<RoomType>> GetRoomTypes()
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return await _content.RoomTypes.ToListAsync();
            }
        }
    }
}
