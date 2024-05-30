using BusinessObject;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class CustomerRepo : ICustomerRepo
    {
        public void AddCustomer(Customer customer)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.Customers.Add(customer);
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }


        }

        public void DeleteCustomerById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.Customers.Remove(_content.Customers.FirstOrDefault(x => x.CustomerId == id));
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }

        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.Customers.FirstOrDefault(x => x.CustomerId == id);
                }
            }
            catch (Exception ex) { return null; }

        }

        public List<Customer> GetCustomers()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return _content.Customers.ToList();
                }
            }
            catch (Exception ex) { return null; }

        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    _content.Customers.Update(customer);
                    _content.SaveChanges();
                }
            }
            catch (Exception ex) { }

        }
    }
}
