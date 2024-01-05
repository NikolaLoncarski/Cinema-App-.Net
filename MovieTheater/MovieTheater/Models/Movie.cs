using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Director { get; set; }
        public string? LeadActor { get; set; }
        public string? Genre { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Duration { get; set; }
        public string Distributer { get; set; }
        public string CountryOfOrigin { get; set; }
        public int YearOfRelease { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
