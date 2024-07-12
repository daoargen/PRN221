using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBookingDetailSer
    {
        Task<IEnumerable<BookingDetail>> GetAllAsync();
        Task<BookingDetail> GetByIdAsync(int id);
        Task<IEnumerable<BookingDetail>> FindAsync(Expression<Func<BookingDetail, bool>> predicate);
        Task<BookingDetail> AddAsync(BookingDetail entity);
        Task<BookingDetail> UpdateAsync(BookingDetail entity);
        Task DeleteAsync(int id);
    }
}
