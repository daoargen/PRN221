using Microsoft.AspNetCore.SignalR;

namespace HotelMini.Hubs
{
    public class BookingDetailHub : Hub
    {
        public async Task SendBookingDetailUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveBookingDetailUpdate", message);
        }
    }
}
