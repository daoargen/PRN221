using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class RoomTypeSer : IRoomTypeSer
    {
        private IRoomTypeRepo _repo;
        public RoomTypeSer()
        {
            _repo = new RoomTypeRepo();
        }

        public List<RoomType> GetRoomTypes()
        {
            return _repo.GetRoomTypes();
        }
    }
}
