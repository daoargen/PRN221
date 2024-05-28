using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class RoomInformationSer : IRoomInformationSer
    {
        private IRoomInformationRepo _repo;
        public RoomInformationSer()
        {
            _repo = new RoomInformationRepo();
        }

        public void AddRoomInformation(RoomInformation roomInformation)
        {
            _repo.AddRoomInformation(roomInformation);
        }

        public void DeleteRoomInformationById(int id)
        {
            _repo.DeleteRoomInformationById(id);
        }

        public List<RoomInformation> GetRoomInformation()
        {
            return _repo.GetRoomInformation();
        }

        public RoomInformation GetRoomInformationById(int id)
        {
            return _repo.GetRoomInformationById(id);
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            _repo.UpdateRoomInformation(roomInformation);
        }
    }
}
