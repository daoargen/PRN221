using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace HotelMini.Pages.BookingReservations
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public IndexModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public IList<BookingReservation> BookingReservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookingReservation = await _context.BookingReservations
                .Include(b => b.Customer).ToListAsync();
        }
    }
}
