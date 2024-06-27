using BusinessObject;
using BusinessObject.DTO;

namespace Repositories.Interface
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetCustomers();
        Task AddCustomer(Customer customer);
        Task DeleteCustomerById(int id);
        Task UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
    }
}
