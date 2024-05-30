using BusinessObject;
using BusinessObject.DTO;
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

        public Customer GetCustomerByMail(string mail)
        {
            return _repo.GetCustomers().FirstOrDefault(x => x.EmailAddress == mail);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            _repo.UpdateCustomer(customer);
        }

        public bool ValidCustomer(string mail, string password)
        {
            Customer currentCustomer = _repo.GetCustomers().FirstOrDefault(x => x.EmailAddress == mail);
            if (currentCustomer == null)
            {
                return false;
            }
            else
            {
                if (currentCustomer.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<CustomerDTO> GetCustomerDTO()
        {
            var customerList = GetCustomers();
            List<CustomerDTO> result = new List<CustomerDTO>();
            foreach (var item in customerList)
            {
                CustomerDTO customer = new CustomerDTO();
                customer.CustomerId = item.CustomerId;
                customer.CustomerFullName = item.CustomerFullName;
                customer.Telephone = item.Telephone;
                customer.CustomerBirthday = item.CustomerBirthday;
                customer.EmailAddress = item.EmailAddress;
                customer.CustomerStatus = item.CustomerStatus;
                result.Add(customer);
            }
            return result;
        }
    }
}
