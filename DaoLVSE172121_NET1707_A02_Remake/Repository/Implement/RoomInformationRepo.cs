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
    public class RoomInformationRepo : IBaseCRUD<RoomInformation>
    {
        public Task<RoomInformation> AddAsync(RoomInformation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomInformation>> FindAsync(Expression<Func<RoomInformation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomInformation>> GetAllAsync()
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.RoomInformations
                        .Include(x => x.RoomType)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoomInformation> GetByIdAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.RoomInformations.FirstAsync(x => x.RoomId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoomInformation> UpdateAsync(RoomInformation entity)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    var room = await _context.RoomInformations.FindAsync(entity.RoomId);
                    if (room != null)
                    {
                        room.RoomStatus = entity.RoomStatus;
                        await _context.SaveChangesAsync();
                    }
                    return room;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
