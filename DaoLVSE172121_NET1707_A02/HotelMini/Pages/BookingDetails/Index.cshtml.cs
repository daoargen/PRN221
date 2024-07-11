using BusinessObject;
using Common.Hubs;
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
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                BookingDetail = await _service.GetBookingDetails();
            }
            else
            {
                var id = HttpContext.Session.GetString("Email");
                BookingDetail = await _service.GetBookingDetailsByCustomerId(id);
            }
        }
    }
}
