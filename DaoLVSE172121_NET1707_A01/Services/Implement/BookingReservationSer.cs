using BusinessObject;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class BookingReservationSer : IBookingReservationSer
    {
        private IBookingReservationRepo _repo;
        public BookingReservationSer(IBookingReservationRepo bookingReservationRepo)
        {
            _repo = bookingReservationRepo;
        }

        public async Task<List<BookingReservation>> GetBookingReservations()
        {
            return await _repo.GetBookingReservations();
        }

        public async Task AddBookingReservation(BookingReservation bookingReservation)
        {
            await _repo.AddBookingReservation(bookingReservation);
        }

        public async Task<List<BookingReservation>> GetBookingReservationByMail(string mail)
        {
            return await _repo.GetBookingReservationByMail(mail);
        }
    }
}
