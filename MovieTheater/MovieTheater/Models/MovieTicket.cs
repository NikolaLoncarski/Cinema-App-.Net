namespace MovieTheater.Models
{
    public class MovieTicket
    {
        public  int Id { get; set; }
        public int ProjectionId  { get; set; }
        public Projection Projection { get; set; }
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public DateTime DateAndTimeOfPurchase    { get; set; }

    }
}
