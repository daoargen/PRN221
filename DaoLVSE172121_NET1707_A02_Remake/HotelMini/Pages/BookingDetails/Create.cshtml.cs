using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject;
using Service.Interface;

namespace HotelMini.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly IBookingDetailSer _context;
        private readonly IBookingReservationSer _reservation;
        private readonly IRoomInformationSer _roomInformation;

        public CreateModel(IBookingDetailSer context, IBookingReservationSer reservation, IRoomInformationSer roomInformation)
        {
            _context = context;
            _reservation = reservation;
            _roomInformation = roomInformation;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["BookingReservationId"] = new SelectList(await _reservation.GetAllAsync(), "BookingReservationId", "BookingReservationId");
        ViewData["RoomId"] = new SelectList(await _roomInformation.GetAllAsync(), "RoomId", "RoomNumber");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            await _context.AddAsync(BookingDetail);

            return RedirectToPage("./Index");
        }
    }
}
