using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }



        [HttpPost]
        [Route("Upload")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {

                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,

                };



                await imageRepository.Upload(imageDomainModel);


                return RedirectToAction("GetById", new { id = imageDomainModel.Id });




            }
            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
            }
        }

        [HttpGet]
        [Route("/api/GetImageByName")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetImageByName([FromQuery] string name)
        {
            return Ok(await imageRepository.GetImage(name));
        }

        [HttpGet]
        [Route("/api/GetImages")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await imageRepository.GetAll());
        }
        [HttpGet]
        [Route("GetById")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetById(int id)
        {

            var Image = await imageRepository.GetByIdAsync(id);

            if (Image == null)
            {
                return NotFound();
            }


            return Ok(Image);
        }
    }
}
