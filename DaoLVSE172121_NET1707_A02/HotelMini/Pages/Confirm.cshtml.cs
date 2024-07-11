using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.Customers
{
    public class ConfirmModel : PageModel
    {
        private readonly ICustomerSer _context;

        public ConfirmModel(ICustomerSer context)
        {
            _context = context;
        }

        public bool IsConfirmed { get; private set; }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string token)
        {
            try
            {
                var customer = await _context.GetCustomerById(int.Parse(userId));

                if (customer == null)
                {
                    ModelState.AddModelError(string.Empty, "Customer not found.");
                    return Page();
                }

                // Xác nhận tài khoản của khách hàng
                customer.CustomerStatus = 1;
                await _context.UpdateCustomer(customer);

                return RedirectToPage("./ConfirmationSuccess");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

    }
}
