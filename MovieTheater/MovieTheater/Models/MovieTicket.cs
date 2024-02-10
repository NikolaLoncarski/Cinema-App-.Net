using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class MovieTicket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Projection id Required!")]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }

        [Required(ErrorMessage = "Seat id Required!")]
        public Guid SeatId { get; set; }
        public Seat? Seat { get; set; }

        public DateTime DateAndTimeOfPurchase { get; set; }

        public Guid UserId { get; set; }


    }
}
