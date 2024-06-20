 using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class RoomTypeSer : IRoomTypeSer
    {
        private IRoomTypeRepo _repo;
        public RoomTypeSer(IRoomTypeRepo roomTypeRepo)
        {
            _repo = roomTypeRepo;
        }

        public async Task<List<RoomType>> GetRoomTypes()
        {
            return await _repo.GetRoomTypes();
        }
    }
}
