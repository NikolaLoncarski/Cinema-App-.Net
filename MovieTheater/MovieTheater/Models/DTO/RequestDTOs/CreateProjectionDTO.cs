namespace MovieTheater.Models.DTO.RequestDTOs
{
    public class CreateProjectionDTO
    {

        public int MovieId { get; set; }


        public int ProjectionTypeId { get; set; }

        public int ProjectionHallId { get; set; }


        public decimal Price { get; set; }

        public DateTime DateAndTimeOfProjecton { get; set; }
    }
}
