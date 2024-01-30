



using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieTheater.Models
{

    public class ProjectionType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Projeciton Type Required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "projecitonHall id Required!")]
        public int ProjectionHallId { get; set; }
        public ProjectionHall ProjectionHall { get; set; } = null!;
    }
}
