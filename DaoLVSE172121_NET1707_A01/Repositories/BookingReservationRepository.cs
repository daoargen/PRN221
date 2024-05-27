using DataAccessObjects;
using DataAccessObjects.DAOs;

namespace Repositories
{
    public class BookingReservationRepository
    {
        public List<BookingReservation> GetBookingReservations() => BookingReservationDAO.GetBookingReservations();
    }
}
