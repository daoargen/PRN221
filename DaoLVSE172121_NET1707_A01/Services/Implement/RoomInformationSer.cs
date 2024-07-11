using BusinessObject;
using BusinessObject.DTO;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class RoomInformationSer : IRoomInformationSer
    {
        private IRoomInformationRepo _repo;
        public RoomInformationSer(IRoomInformationRepo roomInformationRepo)
        {
            _repo = roomInformationRepo;
        }

        public async Task AddRoomInformation(RoomInformation roomInformation)
        {
            await _repo.AddRoomInformation(roomInformation);
        }

        public async Task DeleteRoomInformationById(int id)
        {
            await _repo.DeleteRoomInformationById(id);
        }

        public async Task<List<RoomInformation>> GetRoomInformation()
        {
            return await _repo.GetRoomInformation();
        }

        public async Task<RoomInformation> GetRoomInformationById(int id)
        {
            return await _repo.GetRoomInformationById(id);
        }

        public async Task UpdateRoomInformation(RoomInformationModel roomInformation)
        {
            await _repo.UpdateRoomInformation(roomInformation);
        }
    }
}
