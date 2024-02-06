using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =2,ErrorMessage ="A movie must have a name!")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A movie must have a director!")]
        public string Director { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A movie must have a lead actor!")]
        public string LeadActor { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "A movie must have a lead genre!")]
        public string Genre { get; set; }

        [Required]
        [Range(1, 640, ErrorMessage = "A movie must have a length!")]
        public int Duration { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A movie must have a lead distributer!")]
        public string Distributer { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A movie must have a lead country of origin!")]
        public string CountryOfOrigin { get; set; }

        [Required]
        [Range(1913, 2024, ErrorMessage = "A movie must have a year of release!")]
        public int YearOfRelease { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "A movie must have a description!")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Image id Required!")]
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
