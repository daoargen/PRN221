using DataAccessObjects;
using DataAccessObjects.DAOs;

namespace Repositories
{
    public class BookingDetailRepository
    {
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();
    }
}
