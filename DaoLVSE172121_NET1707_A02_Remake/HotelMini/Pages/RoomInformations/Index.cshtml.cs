using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject;
using Service.Interface;

namespace HotelMini.Pages.RoomInformations
{
    public class IndexModel : PageModel
    {
        private readonly IRoomInformationSer _context;

        public IndexModel(IRoomInformationSer context)
        {
            _context = context;
        }

        public IList<RoomInformation> RoomInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RoomInformation = (await _context.GetAllAsync()).ToList();
        }
    }
}
