


namespace MovieTheater.Models
{
    public class ProjectionHall
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProjectionType> ProjectionTypes { get; } = new List<ProjectionType>();

    }
}
