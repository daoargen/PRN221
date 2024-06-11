using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class BookingReservationRepo : IBookingReservationRepo
    {
        public List<BookingReservation> GetBookingReservations()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.BookingReservations.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
