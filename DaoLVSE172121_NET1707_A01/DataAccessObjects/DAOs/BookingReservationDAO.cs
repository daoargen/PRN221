namespace DataAccessObjects.DAOs
{
    public class BookingReservationDAO
    {
        public static List<BookingReservation> GetBookingReservations(int? id = null)
        {

            var listBookingReservations = new List<BookingReservation>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                if (id != null)
                {
                    listBookingReservations = context.BookingReservations.Where(x => x.CustomerId.Equals(id)).ToList();
                }
                else
                {
                    listBookingReservations = context.BookingReservations.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingReservations;
        }
    }
}
