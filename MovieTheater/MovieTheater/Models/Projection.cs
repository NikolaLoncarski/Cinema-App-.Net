
namespace MovieTheater.Models
{
    public class Projection
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public  int ProjectionTypeId { get; set; }
        public ProjectionType ProjectionType { get; set; }
        public  int ProjectionHallId { get; set; }
        public ProjectionHall ProjectionHall { get; set; }

        public DateTime DateAndTimeOfProjecton { get; set; }
        public decimal Price { get; set; }
        

    }
}
