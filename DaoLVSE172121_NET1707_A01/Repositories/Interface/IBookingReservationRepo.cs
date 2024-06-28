using BusinessObject;

namespace Repositories.Interface
{
    public interface IBookingReservationRepo
    {
        Task<List<BookingReservation>> GetBookingReservations();
        Task AddBookingReservation(BookingReservation bookingReservation);
        Task<List<BookingReservation>> GetBookingReservationByMail(string mail);
    }
}
