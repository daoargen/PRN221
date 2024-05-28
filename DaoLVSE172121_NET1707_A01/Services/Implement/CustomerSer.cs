using BusinessObject;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class CustomerSer : ICustomerSer
    {
        private ICustomerRepo _repo;
        public CustomerSer()
        {
            _repo = new CustomerRepo();
        }

        public void AddCustomer(Customer customer)
        {
            _repo.AddCustomer(customer);
        }

        public void DeleteCustomerById(int id)
        {
            _repo.DeleteCustomerById(id);
        }

        public Customer GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            _repo.UpdateCustomer(customer);
        }
    }
}
