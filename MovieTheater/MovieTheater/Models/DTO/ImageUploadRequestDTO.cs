using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models.DTO
{
    public class ImageUploadRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }

        [Required(ErrorMessage ="bad req")]
        public string FileName { get; set; }


    }
}
