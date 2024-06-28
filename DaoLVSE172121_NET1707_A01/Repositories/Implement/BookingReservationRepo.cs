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

        public async Task AddBookingReservation(BookingReservation bookingReservation)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    await _content.BookingReservations.AddAsync(bookingReservation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BookingReservation>> GetBookingReservationByMail(string mail)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return await _content.Customers.Where(c => c.EmailAddress == mail)
                .SelectMany(c => c.BookingReservations)
                .Include(c => c.Customer)
                .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
