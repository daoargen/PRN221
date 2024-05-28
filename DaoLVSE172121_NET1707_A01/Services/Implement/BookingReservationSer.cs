using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class BookingReservationSer : IBookingDetailSer
    {
        private IBookingReservationRepo _repo;
        public BookingReservationSer()
        {
            _repo = new BookingReservationRepo();
        }

        public List<BookingDetail> GetBookingDetails()
        {
            throw new NotImplementedException();
        }
    }
}
