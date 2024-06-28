using BusinessObject;

namespace Services.Interface
{
    public interface IBookingReservationSer
    {
        Task<List<BookingReservation>> GetBookingReservations();
        Task AddBookingReservation(BookingReservation bookingReservation);
        Task<List<BookingReservation>> GetBookingReservationByMail(string? mail);
    }
}
