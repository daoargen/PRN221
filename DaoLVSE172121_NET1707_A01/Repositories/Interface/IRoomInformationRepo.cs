using BusinessObject;
using BusinessObject.DTO;

namespace Repositories.Interface
{
    public interface IRoomInformationRepo
    {
        Task<List<RoomInformation>> GetRoomInformation();
        Task AddRoomInformation(RoomInformation roomInformation);
        Task DeleteRoomInformationById(int id);
        Task UpdateRoomInformation(RoomInformationModel roomInformation);
        Task<RoomInformation> GetRoomInformationById(int id);
    }
}
