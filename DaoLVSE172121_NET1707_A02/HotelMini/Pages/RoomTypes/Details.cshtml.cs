using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace HotelMini.Pages.RoomTypes
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public DetailsModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomtype = await _context.RoomTypes.FirstOrDefaultAsync(m => m.RoomTypeId == id);
            if (roomtype == null)
            {
                return NotFound();
            }
            else
            {
                RoomType = roomtype;
            }
            return Page();
        }
    }
}
