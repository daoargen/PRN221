using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBookingReservationSer
    {
        Task<IEnumerable<BookingReservation>> GetAllAsync();
        Task<BookingReservation> GetByIdAsync(int id);
        Task<IEnumerable<BookingReservation>> FindAsync(Expression<Func<BookingReservation, bool>> predicate);
        Task<BookingReservation> AddAsync(BookingReservation entity);
        Task<BookingReservation> UpdateAsync(BookingReservation entity);
        Task DeleteAsync(int id);
    }
}
