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
    public class BookingDetailRepo : IBaseCRUD<BookingDetail>
    {
        public async Task<BookingDetail> AddAsync(BookingDetail entity)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    await _context.BookingDetails.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    BookingDetail bookingDetail = await _context.BookingDetails
                        .Include(x => x.BookingReservation)
                        .Include(x => x.Room)
                        .FirstAsync(x => x.BookingDetailId == id);
                    if (bookingDetail != null)
                    {
                        _context.BookingDetails.Remove(bookingDetail);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BookingDetail>> FindAsync(Expression<Func<BookingDetail, bool>> predicate)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.BookingDetails.AsNoTracking().Where(predicate).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BookingDetail>> GetAllAsync()
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.BookingDetails
                        .Include(x => x.BookingReservation)
                        .Include(x => x.Room)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookingDetail> GetByIdAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.BookingDetails.FirstAsync(x => x.BookingDetailId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<BookingDetail> UpdateAsync(BookingDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
