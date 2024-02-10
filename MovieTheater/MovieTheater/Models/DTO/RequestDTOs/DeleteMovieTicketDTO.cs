namespace MovieTheater.Models.DTO.RequestDTOs
{
    public class DeleteMovieTicketDTO
    {
        public int MovieTicketId { get; set; }
        public bool Action { get; set; }
        public string SeatId { get; set; }
    }
}
