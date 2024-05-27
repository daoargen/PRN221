using DataAccessObjects;
using Repositories;

namespace Services
{
    public class BookingDetailService
    {
        private readonly BookingDetailRepository _repository;

        public BookingDetailService(BookingDetailRepository repository)
        {
            _repository = repository;
        }

        public List<BookingDetail> GetBookingDetails() => _repository.GetBookingDetails();
    }
}
