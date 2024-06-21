using BusinessObject;
using BusinessObject.DTO;
using Microsoft.Extensions.Configuration;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class CustomerSer : ICustomerSer
    {
        private ICustomerRepo _repo;
        private string adminEmail;
        private string adminPassword;
        private void GetAdminAccount()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            IConfigurationSection section = config.GetSection("AdminAccount");

            adminEmail = section["Email"];
            adminPassword = section["Password"];
        }

        public bool SignUpWithAdminAccount(string mail)
        {
            if (mail == adminEmail)
            {
                return true;
            }
            return false;
        }

        public CustomerSer(ICustomerRepo customerRepo)
        {
            _repo = customerRepo;
        }

        public async Task AddCustomer(Customer customer)
        {
             await _repo.AddCustomer(customer);
        }

        public async Task DeleteCustomerById(int id)
        {
            await _repo.DeleteCustomerById(id);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repo.GetCustomerById(id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _repo.GetCustomers();
        }

        public async Task UpdateCustomer(CustomerModel customer)
        {
             await _repo.UpdateCustomer(customer);
        }

        public async Task<bool> ValidCustomer(string mail, string password)
        {
            try
            {
                GetAdminAccount();
                if (SignUpWithAdminAccount(mail))
                {
                    if (password == adminPassword)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                List<Customer> customers = await _repo.GetCustomers();
                Customer? currentCustomer = customers.FirstOrDefault(x => x.EmailAddress == mail);
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
            catch (Exception ex)
            {
                throw new Exception("You have no permission to this system!", ex);
            }
        }

        public async Task<List<CustomerModel>> GetCustomerDTO()
        {
            List<Customer> customers = await _repo.GetCustomers();
            List<CustomerModel> result = new List<CustomerModel>();
            foreach (var item in customers)
            {
                CustomerModel customer = new CustomerModel();
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

        public async Task<Customer> GetCustomerByMail(string mail)
        {
            try
            {
                List<Customer> customers = await _repo.GetCustomers();
                Customer? currentCustomer = customers.FirstOrDefault(x => x.EmailAddress == mail);
                if (currentCustomer != null)
                {
                    return currentCustomer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
