using DataAccessObjects;
using DataAccessObjects.DAOs;

namespace Repositories
{
    public class RoomTypeRepository
    {
        public List<RoomType> GetRoomTypes() => RoomTypeDAO.GetRoomTypes();
    }
}
