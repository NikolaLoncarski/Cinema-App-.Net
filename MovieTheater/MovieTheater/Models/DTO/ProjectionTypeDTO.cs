namespace MovieTheater.Models.DTO
{
    public class ProjectionTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int ProjectionHallId { get; set; }
        public string ProjectionHallName { get; set; }
        public int ProjectionHallCapacity { get; set; }
    }
}
