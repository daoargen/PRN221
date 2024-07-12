using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject;
using Service.Interface;
using Service.OtherService;
using System.Security.Cryptography;

namespace HotelMini.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerSer _context;
        private readonly EmailService _emailService;
        private readonly string _baseUrl = "http://localhost:5001";

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

            Customer.CustomerStatus = 0;
            await _context.AddAsync(Customer);

            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var callbackUrl = _emailService.GenerateConfirmationLink(Customer.CustomerId.ToString(), Customer.EmailAddress, token, _baseUrl);

            // Gửi email xác nhận
            await _emailService.SendConfirmationEmailAsync(Customer.EmailAddress, callbackUrl);

            return RedirectToPage("");
        }
    }
}
