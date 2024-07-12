using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject;
using Service.Interface;

namespace HotelMini.Pages.RoomInformations
{
    public class EditModel : PageModel
    {
        private readonly IRoomInformationSer _context;
        private readonly IRoomTypeSer _typeSer;

        public EditModel(IRoomInformationSer context, IRoomTypeSer typeSer)
        {
            _context = context;
            _typeSer = typeSer;
        }

        [BindProperty]
        public RoomInformation RoomInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roominformation =  await _context.GetByIdAsync(id.Value);
            if (roominformation == null)
            {
                return NotFound();
            }
            RoomInformation = roominformation;
            //ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "RoomTypeId", "RoomTypeName");
            ViewData["RoomTypeId"] = new SelectList(await _typeSer.GetAllAsync(), "RoomTypeId", "RoomTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(RoomInformation).State = EntityState.Modified;

            try
            {
                await _context.UpdateAsync(RoomInformation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.GetByIdAsync(RoomInformation.RoomId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
