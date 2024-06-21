using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;

namespace HotelMini.Pages.BookingReservations
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
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "EmailAddress");
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

            _context.BookingReservations.Add(BookingReservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
