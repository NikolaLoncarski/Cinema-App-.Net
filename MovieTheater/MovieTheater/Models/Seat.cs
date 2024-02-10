using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Seat
    {
        public Guid Id { get; set; }

        public bool Reserved { get; set; }

        [Required]
        public int Location { get; set; }
        [Required(ErrorMessage = "A Seat must belong to a projection!")]

        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }

    }
}
