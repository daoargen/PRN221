using BusinessObject;
using Repositories.Implement;
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
    }
}
