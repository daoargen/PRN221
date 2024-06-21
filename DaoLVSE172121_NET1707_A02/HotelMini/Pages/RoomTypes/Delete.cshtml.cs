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
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public DeleteModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomtype = await _context.RoomTypes.FindAsync(id);
            if (roomtype != null)
            {
                RoomType = roomtype;
                _context.RoomTypes.Remove(RoomType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
