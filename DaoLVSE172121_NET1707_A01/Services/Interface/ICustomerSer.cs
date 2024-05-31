using BusinessObject;
using BusinessObject.DTO;

namespace Services.Interface
{
    public interface ICustomerSer
    {
        public List<Customer> GetCustomers();
        public void AddCustomer(Customer customer);
        public void DeleteCustomerById(int id);
        public void UpdateCustomer(Customer customer);
        public Customer GetCustomerById(int id);
        public bool ValidCustomer(string mail, string password);
        public Customer GetCustomerByMail(string mail);
        public List<CustomerDTO> GetCustomerDTO();
        public List<BookingHistory> GetBookingHistories(int id);
    }
}
