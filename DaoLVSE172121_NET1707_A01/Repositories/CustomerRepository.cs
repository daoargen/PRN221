using DataAccessObjects;
using DataAccessObjects.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository
    {
        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();
        public void SaveCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);
        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);  
        public Customer GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);
    }
}
