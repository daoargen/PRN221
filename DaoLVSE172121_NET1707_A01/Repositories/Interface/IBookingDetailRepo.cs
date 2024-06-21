using BusinessObject;

namespace Repositories.Interface
{
    public interface IBookingDetailRepo
    {
        Task<List<BookingDetail>> GetBookingDetail();
        Task DeleteBookingDetails(BookingDetail bookingDetail);
        Task AddBookingDetails(BookingDetail bookingDetail);
    }
}
