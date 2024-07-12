using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class BookingReservationRepo : IBaseCRUD<BookingReservation>
    {
        public Task<BookingReservation> AddAsync(BookingReservation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingReservation>> FindAsync(Expression<Func<BookingReservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingReservation>> GetAllAsync()
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.BookingReservations.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookingReservation> GetByIdAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.BookingReservations.FirstAsync(x => x.BookingReservationId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<BookingReservation> UpdateAsync(BookingReservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
