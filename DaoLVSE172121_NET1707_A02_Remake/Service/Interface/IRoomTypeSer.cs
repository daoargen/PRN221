using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoomTypeSer
    {
        Task<IEnumerable<RoomType>> GetAllAsync();
        Task<RoomType> GetByIdAsync(int id);
        Task<IEnumerable<RoomType>> FindAsync(Expression<Func<RoomType, bool>> predicate);
        Task<RoomType> AddAsync(RoomType entity);
        Task<RoomType> UpdateAsync(RoomType entity);
        Task DeleteAsync(int id);
    }
}
