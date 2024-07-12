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
    public class IndexModel : PageModel
    {
        private readonly ICustomerSer _context;

        public IndexModel(ICustomerSer context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = (await _context.GetAllAsync()).ToList();
        }
    }
}
