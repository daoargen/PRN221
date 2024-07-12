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
    public class RoomTypeSer : IRoomTypeSer
    {
        private readonly IBaseCRUD<RoomType> _repo;

        public RoomTypeSer(IBaseCRUD<RoomType> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            var roomType = await _repo.GetAllAsync();
            return roomType.ToList();
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            var roomType = await _repo.GetByIdAsync(id);
            if (roomType == null)
            {
                throw new KeyNotFoundException($"RoomType with ID {id} not found.");
            }

            return roomType;
        }

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

        public Task<RoomType> UpdateAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
