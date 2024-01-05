using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models.DTO
{
    public class MovieDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Director { get; set; }
        public string? LeadActor { get; set; }
        public string? Genre { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
        public string Distributer { get; set; }
        public string CountryOfOrigin { get; set; }
        public int YearOfRelease { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public string ImageFileName{ get; set; }
        public string ImageFilePath { get; set; }
    }
}
