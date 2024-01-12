namespace MovieTheater.Models
{
    public class Seat
    {
        public Guid Id { get; set; }
   
        public bool Reserved { get; set; }
      
        public int Location { get; set; }
        public int ProjectionId { get; set; }
        public Projection Projection {  get; set; }
   
    }
}
