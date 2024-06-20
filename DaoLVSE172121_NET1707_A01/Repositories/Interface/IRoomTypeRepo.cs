using BusinessObject;

namespace Repositories.Interface
{
    public interface IRoomTypeRepo
    {
        Task<List<RoomType>> GetRoomTypes();
    }
}
