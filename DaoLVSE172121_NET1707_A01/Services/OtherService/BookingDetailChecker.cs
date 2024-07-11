using Common.Hubs;
using Microsoft.AspNetCore.SignalR;
using Services.Interface;

namespace Services.OtherService
{
    public class BookingDetailChecker
    {
        private readonly IBookingDetailSer _bookingDetailSer;
        private readonly IHubContext<BookingDetailHub> _hubContext;

        public BookingDetailChecker(IBookingDetailSer bookingDetailSer, IHubContext<BookingDetailHub> hubContext)
        {
            _bookingDetailSer = bookingDetailSer;
            _hubContext = hubContext;
        }

        public async Task CheckAndNotify()
        {
            var bookingDetails = await _bookingDetailSer.GetBookingDetails();
            var now = DateTime.Now;

            foreach (var bookingDetail in bookingDetails)
            {
                if (bookingDetail.EndDate.ToDateTime(TimeOnly.MinValue) < now)
                {
                    // Logic để cập nhật trạng thái bookingDetail nếu cần
                    _bookingDetailSer.DeleteBookingDetails(bookingDetail);
                    // Thông báo tới client qua SignalR
                    await _hubContext.Clients.All.SendAsync("ReceiveBookingDetailUpdate", "Booking detail updated.");
                }
            }
        }
    }
}
