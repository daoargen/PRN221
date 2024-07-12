using BussinessObject;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class BookingDetailSer : IBookingDetailSer
    {

        private readonly IBaseCRUD<BookingDetail> _repo;

        public BookingDetailSer(IBaseCRUD<BookingDetail> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<BookingDetail>> GetAllAsync()
        {
            var bookingDetail = await _repo.GetAllAsync();
            return bookingDetail.ToList();
        }

        public async Task<BookingDetail> GetByIdAsync(int id)
        {
            var bookingDetail = await _repo.GetByIdAsync(id);
            if (bookingDetail == null)
            {
                throw new KeyNotFoundException($"BookingDetail with ID {id} not found.");
            }

            return bookingDetail;
        }

        public async Task<BookingDetail> AddAsync(BookingDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Customer entity cannot be null.");
            }

            return await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var existingCustomer = await _repo.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            await _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<BookingDetail>> FindAsync(Expression<Func<BookingDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }    

        public Task<BookingDetail> UpdateAsync(BookingDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
