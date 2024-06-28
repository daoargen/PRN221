using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace HotelMini.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerSer _service;

        public EditModel(ICustomerSer customerSer)
        {
            _service = customerSer;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var customer = await _service.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }

                Customer = customer;
                return Page();
            }
            else
            {
                if (HttpContext.Session.GetString("CustomerId").ToString() != id.ToString())
                {
                    return RedirectToPage("/Index");
                }

                if (id == null)
                {
                    return NotFound();
                }

                var customer = await _service.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }

                Customer = customer;
                return Page();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.UpdateCustomer(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }

    }
}
