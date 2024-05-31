using BusinessObject;
using BusinessObject.DTO;
using Repositories.Implement;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class CustomerSer : ICustomerSer
    {
        private ICustomerRepo _cusRepo;
        private IBookingReservationRepo _bookResRepo;
        private IBookingDetailRepo _bookDetRepo;
        private IRoomInformationRepo _roomInfoRepo;
        public CustomerSer()
        {
            _cusRepo = new CustomerRepo();
            _bookResRepo = new BookingReservationRepo();
            _bookDetRepo = new BookingDetailRepo();
            _roomInfoRepo = new RoomInformationRepo();
        }

        public void AddCustomer(Customer customer)
        {
            _cusRepo.AddCustomer(customer);
        }

        public void DeleteCustomerById(int id)
        {
            _cusRepo.DeleteCustomerById(id);
        }

        public Customer GetCustomerById(int id)
        {
            return _cusRepo.GetCustomerById(id);
        }

        public Customer GetCustomerByMail(string mail)
        {
            return _cusRepo.GetCustomers().FirstOrDefault(x => x.EmailAddress == mail);
        }

        public List<Customer> GetCustomers()
        {
            return _cusRepo.GetCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            _cusRepo.UpdateCustomer(customer);
        }

        public bool ValidCustomer(string mail, string password)
        {
            Customer currentCustomer = _cusRepo.GetCustomers().FirstOrDefault(x => x.EmailAddress == mail);
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

        public List<BookingHistory> GetBookingHistories(int id)
        {
            List<BookingHistory> bookingHistories = new List<BookingHistory>();
            var bookingReservation = _bookResRepo.GetBookingReservations().Where(x => x.CustomerId == id).ToList();
            foreach (var currentBookingReservation in bookingReservation)
            {
                var bookingDetail = _bookDetRepo.GetBookingDetail().Where(x => x.BookingReservationId == currentBookingReservation.BookingReservationId).ToList();
                foreach (var currentBookingDetail in bookingDetail)
                {
                    BookingHistory currentBookingHistory = new BookingHistory();
                    currentBookingHistory.StartDate = currentBookingDetail.StartDate;
                    currentBookingHistory.EndDate = currentBookingDetail.EndDate;
                    currentBookingHistory.ActualPrice = currentBookingDetail.ActualPrice;
                    var currentRoomInformation = _roomInfoRepo.GetRoomInformation().FirstOrDefault(x => x.RoomId == currentBookingDetail.RoomId);
                    currentBookingHistory.RoomNumber = currentRoomInformation.RoomNumber;
                    currentBookingHistory.RoomDetailDescription = currentRoomInformation.RoomDetailDescription;
                    currentBookingHistory.RoomMaxCapacity = currentRoomInformation.RoomMaxCapacity;
                    bookingHistories.Add(currentBookingHistory);
                }
            }
            return bookingHistories;
        }
    }
}
