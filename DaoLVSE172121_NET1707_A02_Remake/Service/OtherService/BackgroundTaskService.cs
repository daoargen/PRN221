using BussinessObject;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OtherService
{
    public class BackgroundTaskService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BackgroundTaskService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task UpdateRoomStatusAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var roomRepo = scope.ServiceProvider.GetRequiredService<IBaseCRUD<RoomInformation>>();
                var bookingRepo = scope.ServiceProvider.GetRequiredService<IBaseCRUD<BookingDetail>>();

                var bookingDetails = (await bookingRepo.GetAllAsync()).ToList();
                var rooms = (await roomRepo.GetAllAsync()).ToList();

                foreach (var item in rooms)
                {
                    var existBooking = bookingDetails.FirstOrDefault(x => x.RoomId == item.RoomId);
                    if (existBooking == null)
                    {
                        item.RoomStatus = 1;
                    }
                    else
                    {
                        item.RoomStatus = 0;
                    }
                    await roomRepo.UpdateAsync(item);
                }
            }
        }
        public async Task DeleteExpiredBookingDetailsAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var bookingDetailRepo = scope.ServiceProvider.GetRequiredService<IBaseCRUD<BookingDetail>>();
                var now = DateOnly.FromDateTime(DateTime.Now);

                // Lấy danh sách các BookingDetail đã hết hạn (EndDate < ngày hiện tại)
                var expiredBookingDetails = (await bookingDetailRepo.GetAllAsync())
                    .Where(bd => bd.EndDate < now)
                    .ToList();

                // Xóa từng BookingDetail đã hết hạn
                foreach (var bookingDetail in expiredBookingDetails)
                {
                    await bookingDetailRepo.DeleteAsync(bookingDetail.BookingDetailId);
                }
            }
        }
    }
}