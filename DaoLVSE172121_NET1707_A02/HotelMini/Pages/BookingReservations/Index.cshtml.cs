using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.BookingReservations
{
    public class IndexModel : PageModel
    {
        private readonly IBookingReservationSer _service;

        public IndexModel(IBookingReservationSer bookingReservationSer)
        {
            _service = bookingReservationSer;
        }

        public IList<BookingReservation> BookingReservation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            BookingReservation = await _service.GetBookingReservations();
        }
    }
}
