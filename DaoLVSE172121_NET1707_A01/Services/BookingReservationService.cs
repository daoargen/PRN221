using DataAccessObjects;
using Repositories;

namespace Services
{
    public class BookingReservationService
    {
        private readonly BookingReservationRepository _repository;
        public BookingReservationService(BookingReservationRepository repository)
        {
            _repository = repository;
        }
        public List<BookingReservation> GetBookingReservcations() => _repository.GetBookingReservations();
    }
}
