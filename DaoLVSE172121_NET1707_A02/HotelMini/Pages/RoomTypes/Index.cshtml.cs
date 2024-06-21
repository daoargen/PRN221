using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.RoomTypes
{
    public class IndexModel : PageModel
    {
        private readonly IRoomTypeSer _service;

        public IndexModel(IRoomTypeSer roomTypeSer)
        {
            _service = roomTypeSer;
        }

        public IList<RoomType> RoomType { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoomType = await _service.GetRoomTypes();
        }
    }
}
