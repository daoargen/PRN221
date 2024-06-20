using BusinessObject;
using BusinessObject.DTO;

namespace Services.Interface
{
    public interface IRoomInformationSer
    {
        Task<List<RoomInformation>> GetRoomInformation();
        Task AddRoomInformation(RoomInformation roomInformation);
        Task DeleteRoomInformationById(int id);
        Task UpdateRoomInformation(RoomInformationModel roomInformation);
        Task<RoomInformation> GetRoomInformationById(int id);
        Task<List<RoomInformationModel>> GetRoomInformationDTO();
    }
}
