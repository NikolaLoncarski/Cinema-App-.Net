namespace MovieTheater.Models.DTO.RequestDTOs
{
    public class MovieTicketRequestDTO
    {

        public int ProjectionId { get; set; }

        public int SeatId { get; set; }

        public DateTime DateAndTimeOfPurchase { get; set; }


    }
}
