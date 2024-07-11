using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interface;

namespace HotelMini.Pages.BookingDetails
{
    public class CreateModel : PageModel
    {
        private readonly IBookingDetailSer _bookingDetailService;
        private readonly IBookingReservationSer _bookingReservationService;
        private readonly IRoomInformationSer _roomInformationService;

        public CreateModel(IBookingDetailSer bookingDetailSer, IBookingReservationSer bookingReservationService, IRoomInformationSer roomInformationService)
        {
            _bookingDetailService = bookingDetailSer;
            _bookingReservationService = bookingReservationService;
            _roomInformationService = roomInformationService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["BookingReservationId"] = new SelectList(await _bookingReservationService.GetBookingReservations(), "BookingReservationId", "BookingReservationId");
            // Cái sau là cái view đc, cái trc là value
            ViewData["RoomId"] = new SelectList(await _roomInformationService.GetRoomInformation(), "RoomId", "RoomId");

            //ViewData["BookingReservationId"] = new SelectList(_context.BookingReservations, "BookingReservationId", "BookingReservationId");
            //ViewData["RoomId"] = new SelectList(_context.RoomInformations, "RoomId", "RoomNumber");
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
            //if (!ModelState.IsValid)
            //{
            //    // In ra các lỗi của ModelState
            //    foreach (var modelState in ModelState.Values)
            //    {
            //        foreach (var error in modelState.Errors)
            //        {
            //            Console.WriteLine(error.ErrorMessage);
            //        }
            //    }
            //    ViewData["BookingReservationId"] = new SelectList(await _bookingReservationService.GetBookingReservations(), "BookingReservationId", "BookingReservationId");
            //    ViewData["RoomId"] = new SelectList(await _roomInformationService.GetRoomInformation(), "RoomId", "RoomId");
            //    return Page();
            //}
            await _bookingDetailService.AddBookingDetails(BookingDetail);
            Console.WriteLine("BookingDetail has been added successfully.");

            return RedirectToPage("./Index");
        }
    }
}
