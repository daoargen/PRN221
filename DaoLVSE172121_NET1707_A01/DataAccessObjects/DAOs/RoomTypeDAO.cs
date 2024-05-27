namespace DataAccessObjects.DAOs
{
    public class RoomTypeDAO
    {
        public static List<RoomType> GetRoomTypes()
        {
            var listRoomType = new List<RoomType>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listRoomType = context.RoomTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoomType;
        }
    }
}
