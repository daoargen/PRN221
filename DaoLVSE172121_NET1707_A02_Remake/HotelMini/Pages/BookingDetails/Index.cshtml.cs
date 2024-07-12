using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject;
using Service.Interface;

namespace HotelMini.Pages.BookingDetails
{
    public class IndexModel : PageModel
    {
        private readonly IBookingDetailSer _context;

        public IndexModel(IBookingDetailSer context)
        {
            _context = context;
        }

        public IList<BookingDetail> BookingDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookingDetail = (await _context.GetAllAsync()).ToList();
        }
    }
}
