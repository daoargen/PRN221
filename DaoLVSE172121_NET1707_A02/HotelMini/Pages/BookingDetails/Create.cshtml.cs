using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;

namespace HotelMini.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public CreateModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingReservationId"] = new SelectList(_context.BookingReservations, "BookingReservationId", "BookingReservationId");
        ViewData["RoomId"] = new SelectList(_context.RoomInformations, "RoomId", "RoomNumber");
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

            _context.BookingDetails.Add(BookingDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
