using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoomInformationSer
    {
        Task<IEnumerable<RoomInformation>> GetAllAsync();
        Task<RoomInformation> GetByIdAsync(int id);
        Task<IEnumerable<RoomInformation>> FindAsync(Expression<Func<RoomInformation, bool>> predicate);
        Task<RoomInformation> AddAsync(RoomInformation entity);
        Task<RoomInformation> UpdateAsync(RoomInformation entity);
        Task DeleteAsync(int id);
    }
}
