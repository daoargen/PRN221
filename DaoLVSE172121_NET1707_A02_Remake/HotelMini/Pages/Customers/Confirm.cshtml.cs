using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace HotelMini.Pages.Customers
{
    public class ConfirmModel : PageModel
    {
        private readonly ICustomerSer _context;

        public ConfirmModel(ICustomerSer context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var customer = await _context.GetByIdAsync(int.Parse(userId));

            if (customer == null || customer.EmailAddress != email || customer.CustomerStatus == 1)
            {
                return NotFound(); // Ho?c chuy?n h??ng ??n trang l?i khác
            }

            // Xác th?c token (B?n nên có c? ch? xác th?c token an toàn h?n)
            // ...

            customer.CustomerStatus = 1;
            await _context.UpdateAsync(customer);

            return Page();
        }
    }
}