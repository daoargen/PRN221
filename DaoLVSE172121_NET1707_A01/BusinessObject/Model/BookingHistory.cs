namespace BusinessObject.DTO
{
    public class BookingHistory
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public decimal? ActualPrice { get; set; }

        public string RoomNumber { get; set; } = null!;

        public string? RoomDetailDescription { get; set; }

        public int? RoomMaxCapacity { get; set; }

    }
}
