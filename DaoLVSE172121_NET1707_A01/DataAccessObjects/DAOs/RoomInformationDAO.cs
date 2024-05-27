namespace DataAccessObjects.DAOs
{
    public class RoomInformationDAO
    {
        public static List<RoomInformation> GetRoomInformation()
        {
            var listRoomInformation = new List<RoomInformation>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listRoomInformation = context.RoomInformations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoomInformation;
        }
        public static void SaveRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.RoomInformations.Add(roomInformation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<RoomInformation>(roomInformation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var a = context.RoomInformations.SingleOrDefault(x => roomInformation.RoomId == x.RoomId);
                context.RoomInformations.Remove(a);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static RoomInformation GetRoomInformationById(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.FirstOrDefault(x => x.RoomId.Equals(id));
        }
    }
}
