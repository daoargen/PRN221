using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICustomerSer
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate);
        Task<Customer> AddAsync(Customer entity);
        Task<Customer> UpdateAsync(Customer entity);
        Task DeleteAsync(int id);
        Task<bool> ValidCustomer(string mail, string password);
        public bool SignUpWithAdminAccount(string mail);
    }
}
