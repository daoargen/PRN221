using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class BookingReservationRepo : IBookingReservationRepo
    {
        public async Task<List<BookingReservation>> GetBookingReservations()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return await _content.BookingReservations.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
