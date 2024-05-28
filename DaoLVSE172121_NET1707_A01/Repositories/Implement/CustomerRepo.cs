using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class CustomerRepo : ICustomerRepo
    {
        public void AddCustomer(Customer customer)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                _content.Customers.Add(customer);
                _content.SaveChanges();
            }
        }

        public void DeleteCustomerById(int id)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {

                _content.Customers.Remove(_content.Customers.FirstOrDefault(x => x.CustomerId == id));
                _content.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.Customers.FirstOrDefault(x => x.CustomerId == id);
            }
        }

        public List<Customer> GetCustomers()
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                return _content.Customers.ToList();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
            {
                _content.Customers.Update(customer);
                _content.SaveChanges();
            }
        }
    }
}
