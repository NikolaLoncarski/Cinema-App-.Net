namespace MovieTheater.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public  string  SeatLocation { get; set; }
        public bool Reserved { get; set; }
        public int  ProjectionHallId    { get; set; }
        public ProjectionHall ProjectionHall { get; set; }
    }
}
