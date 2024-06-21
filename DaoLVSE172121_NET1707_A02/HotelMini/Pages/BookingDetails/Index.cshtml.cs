using BusinessObject;
using HotelMini.Hubs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Services.Interface;

namespace HotelMini.Pages.BookingDetails
{
    public class IndexModel : PageModel
    {
        private readonly IBookingDetailSer _service;
        private readonly IHubContext<BookingDetailHub> _hubContext;

        public IndexModel(IBookingDetailSer bookingDetailSer, IHubContext<BookingDetailHub> hubContext)
        {
            _service = bookingDetailSer;
            _hubContext = hubContext;
        }

        public IList<BookingDetail> BookingDetail { get; set; } = default!;

        public async Task OnGetAsync()
        {
            BookingDetail = await _service.GetBookingDetails();
        }
        public async Task OnPostRemoveExpiredAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var expiredDetails = BookingDetail.Where(bd => bd.EndDate < today).ToList();
            foreach (var detail in expiredDetails)
            {
                // Xóa các booking detail đã hết hạn từ cơ sở dữ liệu
                await _service.DeleteBookingDetails(detail);
                // Gửi thông báo tới các client qua SignalR
                await _hubContext.Clients.All.SendAsync("ReceiveBookingDetailUpdate", "Booking details updated.");
            }

            // Tải lại danh sách cập nhật sau khi xóa
            BookingDetail = await _service.GetBookingDetails();
        }
    }
}
