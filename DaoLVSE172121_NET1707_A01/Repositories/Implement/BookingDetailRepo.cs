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
        public async Task DeleteBookingDetails(BookingDetail bookingDetail)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.BookingDetails.Remove(bookingDetail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddBookingDetails(BookingDetail bookingDetail)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    await _content.BookingDetails.AddAsync(bookingDetail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
