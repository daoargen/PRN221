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
    public class RoomTypeRepo : IBaseCRUD<RoomType>
    {
        public Task<RoomType> AddAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomType>> FindAsync(Expression<Func<RoomType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.RoomTypes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.RoomTypes.FirstAsync(x => x.RoomTypeId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<RoomType> UpdateAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
