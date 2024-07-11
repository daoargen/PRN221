using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;
using System.Security.Cryptography;

namespace HotelMini.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerSer _context;
        private readonly EmailService _emailService;
        private readonly string _baseUrl = "http://localhost:5243"; // URL của ứng dụng

        public CreateModel(ICustomerSer context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Lưu khách hàng tạm thời với trạng thái chưa xác nhận
                Customer.CustomerStatus = 0;
                await _context.AddCustomer(Customer);

                // Tạo một mã xác nhận duy nhất
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                var callbackUrl = _emailService.GenerateConfirmationLink(Customer.CustomerId.ToString(), Customer.EmailAddress, token, _baseUrl);

                // Gửi email xác nhận
                await _emailService.SendConfirmationEmailAsync(Customer.EmailAddress, callbackUrl);

                return RedirectToPage("");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

    }
}
