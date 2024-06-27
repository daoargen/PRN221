using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerSer _ser;

        public LoginModel(ICustomerSer customerSer)
        {
            _ser = customerSer;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (await _ser.ValidCustomer(Email, Password))
            {
                var customerAccount = await _ser.GetCustomerByMail(Email);

                HttpContext.Session.SetString("Email", Email);
                if (!_ser.SignUpWithAdminAccount(Email))
                {
                    HttpContext.Session.SetString("CustomerId", customerAccount.CustomerId.ToString());
                }

                // Redirect to the home page or dashboard
                return RedirectToPage("/Index");
            }
            else
            {
                // Add an error message
                ModelState.AddModelError("", "You have no permission to this system!");
                return Page();
            }
        }
    }
}
