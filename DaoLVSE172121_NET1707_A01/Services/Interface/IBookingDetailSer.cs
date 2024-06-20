using BusinessObject;

namespace Services.Interface
{
    public interface IBookingDetailSer
    {
        Task<List<BookingDetail>> GetBookingDetails();
    }
}
