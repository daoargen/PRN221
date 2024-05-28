using BusinessObject;

namespace Repositories.Interface
{
    public interface IBookingReservationRepo
    {
        public List<BookingReservation> GetBookingReservations();
    }
}
