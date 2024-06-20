using BusinessObject;

namespace Repositories.Interface
{
    public interface IBookingDetailRepo
    {
        Task<List<BookingDetail>> GetBookingDetail();
    }
}
