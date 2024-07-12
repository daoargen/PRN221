using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject;

namespace HotelMini.Pages.BookingDetails
{
    public class DetailsModel : PageModel
    {
        private readonly BussinessObject.FuminiHotelManagementContext _context;

        public DetailsModel(BussinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public BookingDetail BookingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = await _context.BookingDetails.FirstOrDefaultAsync(m => m.BookingDetailId == id);
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
    }
}
