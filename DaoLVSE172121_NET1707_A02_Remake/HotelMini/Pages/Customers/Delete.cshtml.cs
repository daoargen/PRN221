using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject;
using Service.Interface;

namespace HotelMini.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerSer _context;

        public DeleteModel(ICustomerSer context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var customer = await _context.GetByIdAsync(id.Value);

                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    Customer = customer;
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.GetByIdAsync(id.Value);
            if (customer != null)
            {
                Customer = customer;
                await _context.DeleteAsync(id.Value);               
            }

            return RedirectToPage("./Index");
        }
    }
}
