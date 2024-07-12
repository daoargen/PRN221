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
    public class RoomInformationSer : IRoomInformationSer
    {
        private readonly IBaseCRUD<RoomInformation> _repo;

        public RoomInformationSer(IBaseCRUD<RoomInformation> roomRepo)
        {
            _repo = roomRepo ?? throw new ArgumentNullException(nameof(roomRepo));
        }

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
            var roomInformations = await _repo.GetAllAsync();
            return roomInformations.ToList();
        }

        public async Task<RoomInformation> GetByIdAsync(int id)
        {
            var roomInformation = await _repo.GetByIdAsync(id);
            if (roomInformation == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return roomInformation;
        }

        public async Task<RoomInformation> UpdateAsync(RoomInformation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order entity cannot be null.");
            }

            var existingCustomer = await _repo.GetByIdAsync(entity.RoomId);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Order with ID {entity.RoomId} not found.");
            }

            return await _repo.UpdateAsync(entity);
        }
    }
}
