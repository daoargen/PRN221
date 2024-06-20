using BusinessObject;

namespace Services.Interface
{
    public interface IRoomTypeSer
    {
        Task<List<RoomType>> GetRoomTypes();
    }
}
