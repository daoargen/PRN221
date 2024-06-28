using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly IBookingDetailSer _service;

        public CreateModel(IBookingDetailSer bookingDetailSer)
        {
            _service = bookingDetailSer;
        }

        public IActionResult OnGet()
        {
            //ViewData["BookingReservationId"] = new SelectList(_context.BookingReservations, "BookingReservationId", "BookingReservationId");
            //ViewData["RoomId"] = new SelectList(_context.RoomInformations, "RoomId", "RoomNumber");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _service.AddBookingDetails(BookingDetail);


            return RedirectToPage("./Index");
        }
    }
}
