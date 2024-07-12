using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject;

namespace HotelMini.Pages.BookingDetails
{
    public class EditModel : PageModel
    {
        private readonly BussinessObject.FuminiHotelManagementContext _context;

        public EditModel(BussinessObject.FuminiHotelManagementContext context)
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

            var bookingdetail =  await _context.BookingDetails.FirstOrDefaultAsync(m => m.BookingDetailId == id);
            if (bookingdetail == null)
            {
                return NotFound();
            }
            BookingDetail = bookingdetail;
           ViewData["BookingReservationId"] = new SelectList(_context.BookingReservations, "BookingReservationId", "BookingReservationId");
           ViewData["RoomId"] = new SelectList(_context.RoomInformations, "RoomId", "RoomNumber");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(BookingDetail.BookingDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetails.Any(e => e.BookingDetailId == id);
        }
    }
}
