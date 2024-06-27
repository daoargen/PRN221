using BusinessObject;
using BusinessObject.DTO;

namespace Services.Interface
{
    public interface ICustomerSer
    {
        Task<List<Customer>> GetCustomers();
        Task AddCustomer(Customer customer);
        Task DeleteCustomerById(int id);
        Task UpdateCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<bool> ValidCustomer(string mail, string password);
        Task<List<CustomerModel>> GetCustomerDTO();
        public bool SignUpWithAdminAccount(string mail);
        Task<Customer> GetCustomerByMail(string mail);
    }
}
