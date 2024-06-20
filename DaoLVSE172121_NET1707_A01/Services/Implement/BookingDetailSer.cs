using BusinessObject;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class BookingDetailSer : IBookingDetailSer
    {
        private IBookingDetailRepo _repo;
        public BookingDetailSer(IBookingDetailRepo bookingDetailRepo)
        {
            _repo = bookingDetailRepo;
        }

        public async Task<List<BookingDetail>> GetBookingDetails()
        {
            return await _repo.GetBookingDetail();
        }
    }
}
