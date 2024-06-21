using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Interface;

namespace HotelMini.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerSer _service;

        public IndexModel(ICustomerSer customerSer)
        {
            _service = customerSer;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _service.GetCustomers();
        }
    }
}
