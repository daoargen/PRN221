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
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.FuminiHotelManagementContext _context;

        public IndexModel(BusinessObject.FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public IList<RoomType> RoomType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RoomType = await _context.RoomTypes.ToListAsync();
        }
    }
}
