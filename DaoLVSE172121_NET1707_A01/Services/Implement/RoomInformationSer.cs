using BusinessObject;
using BusinessObject.DTO;
using Repositories.Implement;
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
        public async Task<List<RoomInformationModel>> GetRoomInformationDTO()
        {
            List<RoomInformationModel> roomInformationDTOs = new List<RoomInformationModel>();
            List<RoomInformation> roomInformations = await _repo.GetRoomInformation();
            foreach (RoomInformation roomInformation in roomInformations)
            {
                RoomInformationModel roomInformationDTO = new RoomInformationModel();
                roomInformationDTO.RoomId = roomInformation.RoomId;
                roomInformationDTO.RoomNumber = roomInformation.RoomNumber;
                roomInformationDTO.RoomDetailDescription = roomInformation.RoomDetailDescription;
                roomInformationDTO.RoomMaxCapacity = roomInformation.RoomMaxCapacity;
                roomInformationDTO.RoomTypeId = roomInformation.RoomTypeId;
                roomInformationDTO.RoomStatus = roomInformation.RoomStatus;
                roomInformationDTO.RoomPricePerDay = roomInformation.RoomPricePerDay;
                roomInformationDTOs.Add(roomInformationDTO);
            }
            return roomInformationDTOs;
        }
    }
}
