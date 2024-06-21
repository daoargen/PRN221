using BusinessObject;

namespace Services.Interface
{
    public interface IBookingDetailSer
    {
        Task<List<BookingDetail>> GetBookingDetails();
        Task DeleteBookingDetails(BookingDetail bookingDetail);
        Task AddBookingDetails(BookingDetail bookingDetail);
    }
}
