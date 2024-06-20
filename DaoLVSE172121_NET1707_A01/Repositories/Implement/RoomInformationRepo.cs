using BusinessObject;
using BusinessObject.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class RoomInformationRepo : IRoomInformationRepo
    {
        public async Task AddRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    await _content.RoomInformations.AddAsync(roomInformation);
                    await _content.SaveChangesAsync();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteRoomInformationById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var existRoomInformation = 
                        await _content.RoomInformations.FirstOrDefaultAsync(x => x.RoomId == id);
                    if (existRoomInformation != null)
                    {
                        var existBookingDetails = await _content.BookingDetails.Where(bd => bd.RoomId == id).ToListAsync();
                        if (existBookingDetails.Any())
                        {
                            _content.BookingDetails.RemoveRange(existBookingDetails);
                        }
                        _content.RoomInformations.Remove(existRoomInformation);
                        await _content.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RoomInformation>> GetRoomInformation()
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    return await _content.RoomInformations.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoomInformation?> GetRoomInformationById(int id)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var existRominformation = await _content.RoomInformations.FirstOrDefaultAsync(x => x.RoomId == id);
                    if (existRominformation != null)
                    {
                        return existRominformation;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRoomInformation(RoomInformationModel roomInformation)
        {
            try
            {
                using (FuminiHotelManagementContext _content = new FuminiHotelManagementContext())
                {
                    var updateRoomInformation = await _content.RoomInformations.FirstOrDefaultAsync(X => X.RoomId == roomInformation.RoomId);
                    if (updateRoomInformation != null)
                    {
                        updateRoomInformation.RoomNumber = roomInformation.RoomNumber;
                        updateRoomInformation.RoomDetailDescription = roomInformation.RoomDetailDescription;
                        updateRoomInformation.RoomMaxCapacity = roomInformation.RoomMaxCapacity;
                        updateRoomInformation.RoomTypeId = roomInformation.RoomTypeId;
                        updateRoomInformation.RoomStatus = roomInformation.RoomStatus;
                        updateRoomInformation.RoomPricePerDay = roomInformation.RoomPricePerDay;
                        await _content.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
