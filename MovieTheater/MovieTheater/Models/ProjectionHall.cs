


using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class ProjectionHall
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Projection Hall Name required!")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100,ErrorMessage ="Hall capacity must be between 1 and 100!")]
        public int Capacity { get; set; }

        public ICollection<ProjectionType> ProjectionTypes { get; } = new List<ProjectionType>();

    }
}
