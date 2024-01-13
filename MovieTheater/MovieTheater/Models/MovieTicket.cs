namespace MovieTheater.Models
{
    public class MovieTicket
    {
        public  int Id { get; set; }
        public int ProjectionId  { get; set; }
        public Projection Projection { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
        public DateTime DateAndTimeOfPurchase    { get; set; }
        public Guid UserId { get; set; }


    }
}
