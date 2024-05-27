namespace DataAccessObjects.DAOs
{
    public class BookingDetailDAO
    {
        public static List<BookingDetail> GetBookingDetails()
        {
            var listBookingDetails = new List<BookingDetail>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listBookingDetails = context.BookingDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingDetails;
        }

        public static void SaveBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.BookingDetails.Add(bookingDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateProduct(BookingDetail bookingDetail)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<BookingDetail>(bookingDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
