
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Projection
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie id Required!")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required(ErrorMessage = "Projection Type id Required!")]
        public int ProjectionTypeId { get; set; }
        public ProjectionType ProjectionType { get; set; }

        [Required(ErrorMessage = "Hall id Required!")]
        public int ProjectionHallId { get; set; }
        public ProjectionHall ProjectionHall { get; set; }

        [Required(ErrorMessage = "Date and Time of projection required!")]
        public DateTime DateAndTimeOfProjecton { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Price Required, must be between 1 and 1000")]
        public decimal Price { get; set; }


    }
}
