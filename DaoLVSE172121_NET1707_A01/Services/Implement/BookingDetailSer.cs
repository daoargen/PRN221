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

        public async Task DeleteBookingDetails(BookingDetail bookingDetail)
        {
            await _repo.DeleteBookingDetails(bookingDetail);
        }

        public async Task AddBookingDetails(BookingDetail bookingDetail)
        {
            await _repo.AddBookingDetails(bookingDetail);
        }
    }
}
