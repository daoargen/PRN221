using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class BookingDetailRepo : IBookingDetailRepo
    {
        public List<BookingDetail> GetBookingDetail()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.BookingDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
