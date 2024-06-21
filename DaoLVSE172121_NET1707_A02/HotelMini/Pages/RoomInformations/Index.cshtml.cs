using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.RoomInformations
{
    public class IndexModel : PageModel
    {
        private readonly IRoomInformationSer _service;

        public IndexModel(IRoomInformationSer roomInformationSer)
        {
            _service = roomInformationSer;
        }

        public IList<RoomInformation> RoomInformation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoomInformation = await _service.GetRoomInformation();
        }
    }
}
