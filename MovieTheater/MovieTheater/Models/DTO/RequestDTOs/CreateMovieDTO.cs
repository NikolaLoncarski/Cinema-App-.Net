namespace MovieTheater.Models.DTO.RequestDTOs
{
    public class CreateMovieDTO
    {

        public string Name { get; set; }
        public string? Director { get; set; }
        public string? LeadActor { get; set; }
        public string? Genre { get; set; }

        public int Duration { get; set; }
        public string Distributer { get; set; }
        public string CountryOfOrigin { get; set; }
        public int YearOfRelease { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }


    }
}
