namespace MovieTheater.Models
{
    public class Seat
    {
        public int Id { get; set; }
   
        public bool Reserved { get; set; }
      
        public int ProjectionId { get; set; }
        public Projection Projection {  get; set; }
        public  int AvailableSeatsId { get; set; }
        public  AvailableSeats AvailableSeats { get; set; }
    }
}
