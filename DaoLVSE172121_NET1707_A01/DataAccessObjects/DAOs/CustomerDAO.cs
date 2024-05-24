using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.DAOs
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            var listCustomers = new List<Customer>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listCustomers = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCustomers;
        }
        public static void SaveCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var a = context.Customers.SingleOrDefault(x => customer.CustomerId == x.CustomerId);
                context.Customers.Remove(a);
                context.SaveChanges();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Customer GetCustomerById(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.Customers.FirstOrDefault(x => x.CustomerId.Equals(id));
        }
    }
}
