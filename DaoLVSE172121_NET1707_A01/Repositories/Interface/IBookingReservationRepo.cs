using BusinessObject;

namespace Repositories.Interface
{
    public interface IBookingReservationRepo
    {
        Task<List<BookingReservation>> GetBookingReservations();
    }
}
