using Microsoft.AspNetCore.Mvc;

namespace HotelMini
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }
    }
}
