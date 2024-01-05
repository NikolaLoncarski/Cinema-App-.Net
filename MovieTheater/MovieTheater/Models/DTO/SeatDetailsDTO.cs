namespace MovieTheater.Models.DTO
{
    public class SeatDetailsDTO
    {
        public int Id { get; set; }
        public string SeatLocation { get; set; }
        public int ProjectionHallId { get; set; }
        public string ProjectionHallName { get; set; }
    }
}
