using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.BookingReservations
{
    public class CreateModel : PageModel
    {
        private readonly IBookingReservationSer _service;

        public CreateModel(IBookingReservationSer bookingReservation)
        {
            _service = bookingReservation;
        }

        public IActionResult OnGet()
        {
            //ViewData["CustomerId"] = new SelectList(_service.Customers, "CustomerId", "EmailAddress");
            return Page();
        }

        [BindProperty]
        public BookingReservation BookingReservation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddBookingReservation(BookingReservation);
            return RedirectToPage("./Index");
        }
    }
}
