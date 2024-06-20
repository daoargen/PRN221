using BusinessObject;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class BookingDetailSer : IBookingDetailSer
    {
        private IBookingDetailRepo _repo;
        public BookingDetailSer(IBookingDetailRepo bookingRepo)
        {
            _repo = bookingRepo;
        }

        public Task<List<BookingDetail>> GetBookingDetails()
        {
            return _repo.GetBookingDetail();
        }
    }
}
