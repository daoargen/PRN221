using DataAccessObjects;
using Repositories;

namespace Services
{
    public class RoomInformationService
    {
        private readonly RoomInformationRepository _repository;

        public RoomInformationService(RoomInformationRepository repository)
        {
            _repository = repository;
        }

        public List<RoomInformation> GetRoomInformation() => _repository.GetRoomInformation();
    }
}
