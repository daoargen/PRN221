using BusinessObject;
using BusinessObject.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class CustomerRepo : ICustomerRepo
    {
        public async Task AddCustomer(Customer customer)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    await _content.Customers.AddAsync(customer);
                    await _content.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCustomerById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var existCustomer =
                        await _content.Customers
                        .Include(a => a.BookingReservations)
                        .ThenInclude(b => b.BookingDetails)
                        .FirstOrDefaultAsync(x => x.CustomerId == id);
                    if (existCustomer != null)
                    {
                        foreach (var reservation in existCustomer.BookingReservations)
                        {
                            _content.BookingDetails.RemoveRange(reservation.BookingDetails);
                        }
                        _content.BookingReservations.RemoveRange(existCustomer.BookingReservations);
                        _content.Customers.Remove(existCustomer);
                        await _content.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var existCustomer = await _content.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
                    if (existCustomer != null)
                    {
                        return existCustomer;
                    }
                    else
                    {
                        throw new ArgumentException("Customer not found", nameof(id));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {

                    return await _content.Customers.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCustomer(CustomerModel customer)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var neededUpdateCustomer = await _content.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
                    if (neededUpdateCustomer != null)
                    {
                        neededUpdateCustomer.CustomerFullName = customer.CustomerFullName;
                        neededUpdateCustomer.Telephone = customer.Telephone;
                        neededUpdateCustomer.EmailAddress = customer.EmailAddress;
                        neededUpdateCustomer.CustomerStatus = customer.CustomerStatus;
                        await _content.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Customer not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
