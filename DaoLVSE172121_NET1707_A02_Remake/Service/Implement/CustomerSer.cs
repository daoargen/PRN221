using BussinessObject;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    public class CustomerSer : ICustomerSer
    {
        private readonly IBaseCRUD<Customer> _repo;
        private string adminEmail;
        private string adminPassword;

        public CustomerSer(IBaseCRUD<Customer> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

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

                List<Customer> customers = (await _repo.GetAllAsync()).ToList();
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

        public async Task<Customer> AddAsync(Customer entity)
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

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            var customer = await _repo.FindAsync(predicate);
            return customer.ToList();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customer = await _repo.GetAllAsync();
            return customer.ToList();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _repo.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Order entity cannot be null.");
            }

            var existingCustomer = await _repo.GetByIdAsync(entity.CustomerId);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Order with ID {entity.CustomerId} not found.");
            }

            return await _repo.UpdateAsync(entity);
        }
    }
}
