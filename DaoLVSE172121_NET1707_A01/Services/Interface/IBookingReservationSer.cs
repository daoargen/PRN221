using BusinessObject;

namespace Services.Interface
{
    public interface IBookingReservationSer
    {
        Task<List<BookingReservation>> GetBookingReservations();
    }
}
