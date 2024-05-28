using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class BookingDetailRepo : IBookingDetailRepo
    {
        public List<BookingDetail> GetBookingDetail()
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.BookingDetails.ToList();
            }
        }
    }
}
