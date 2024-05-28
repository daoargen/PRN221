using BusinessObject;

namespace Repositories.Interface
{
    public interface ICustomerRepo
    {
        public List<Customer> GetCustomers();
        public void AddCustomer(Customer customer);
        public void DeleteCustomerById(int id);
        public void UpdateCustomer(Customer customer);
        public Customer GetCustomerById(int id);
    }
}
