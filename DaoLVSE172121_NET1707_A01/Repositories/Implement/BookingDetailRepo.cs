using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class BookingDetailRepo : IBookingDetailRepo
    {
        public async Task<List<BookingDetail>> GetBookingDetail()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return await _content.BookingDetails.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
