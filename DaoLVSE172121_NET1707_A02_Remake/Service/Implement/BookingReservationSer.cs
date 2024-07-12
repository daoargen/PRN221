using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using System.Linq.Expressions;
using Repository.Interface;

namespace Service.Implement
{
    public class BookingReservationSer : IBookingReservationSer
    {
        private readonly IBaseCRUD<BookingReservation> _repo;

        public BookingReservationSer(IBaseCRUD<BookingReservation> roomRepo)
        {
            _repo = roomRepo ?? throw new ArgumentNullException(nameof(roomRepo));
        }

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
            var bookingReservation = await _repo.GetAllAsync();
            return bookingReservation.ToList();
        }

        public async Task<BookingReservation> GetByIdAsync(int id)
        {
            var bookingReservation = await _repo.GetByIdAsync(id);
            if (bookingReservation == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return bookingReservation;
        }

        public Task<BookingReservation> UpdateAsync(BookingReservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
