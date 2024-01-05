



using System.Text.Json.Serialization;

namespace MovieTheater.Models
{

    public class ProjectionType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int ProjectionHallId { get; set; }
        public ProjectionHall ProjectionHall { get; set; } = null!;
    }
}
