using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace HotelMini.Pages.BookingDetails
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public DeleteModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = await _context.BookingDetails.FirstOrDefaultAsync(m => m.BookingReservationId == id);

            if (bookingdetail == null)
            {
                return NotFound();
            }
            else
            {
                BookingDetail = bookingdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = await _context.BookingDetails.FindAsync(id);
            if (bookingdetail != null)
            {
                BookingDetail = bookingdetail;
                _context.BookingDetails.Remove(BookingDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
