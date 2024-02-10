namespace MovieTheater.Models.DTO.RequestDTOs
{
    public class MovieTicketRequestDTO
    {

        public int ProjectionId { get; set; }

        public Guid SeatId { get; set; }

        public DateTime? DateAndTimeOfPurchase { get; set; }
        public bool Action { get; set; }
        public Guid? UserId { get; set; }
    }
}
