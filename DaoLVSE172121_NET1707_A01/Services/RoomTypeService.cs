using DataAccessObjects;
using Repositories;

namespace Services
{
    public class RoomTypeService
    {
        private readonly RoomTypeRepository _repository;

        public RoomTypeService(RoomTypeRepository repository)
        {
            _repository = repository;
        }

        public List<RoomInformation> Get() => _repository.GetRoomInformation();
    }
}
