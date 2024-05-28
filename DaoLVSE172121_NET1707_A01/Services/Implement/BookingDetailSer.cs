using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class BookingDetailSer : IBookingDetailSer
    {
        private IBookingDetailRepo _repo;
        public BookingDetailSer()
        {
            _repo = new BookingDetailRepo();
        }

        public List<BookingDetail> GetBookingDetails()
        {
            return _repo.GetBookingDetail();
        }
    }
}
