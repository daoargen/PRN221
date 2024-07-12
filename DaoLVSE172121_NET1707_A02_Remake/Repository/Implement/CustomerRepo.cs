using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class CustomerRepo : IBaseCRUD<Customer>
    {
        public async Task<Customer> AddAsync(Customer entity)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    await _context.Customers.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    var customer = await _context.Customers.FindAsync(id);
                    if (customer != null)
                    {
                        _context.Customers.Remove(customer);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.Customers.AsNoTracking().Where(predicate).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.Customers.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    return await _context.Customers.FirstAsync(x => x.CustomerId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            try
            {
                using (var _context = new FuminiHotelManagementContext())
                {
                    var customer = await _context.Customers.FindAsync(entity.CustomerId);
                    if (customer != null)
                    {
                        customer.CustomerFullName = entity.CustomerFullName;
                        customer.Telephone = entity.Telephone;
                        customer.CustomerStatus = entity.CustomerStatus;
                        await _context.SaveChangesAsync();
                    }
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
