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




        /// <summary>
        /// Upload an Image
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Uploaded Image</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Upload
        ///     {File:"file",
        ///      FileName:"fileName"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns Created if Upload is successfull</response>
        /// <response code="400">If the Request is bad</response>
        /// <response code="403">Returns Foribiden if user role isnt "Admin"</response>
        [HttpPost]
        [Route("Upload")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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



        /// <summary>
        ///Get Image By Image Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Image</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /GetImageByName?name="imageName"
        ///
        /// </remarks>
        /// <response code="200">Returns Image</response>
        /// <response code="400">If the Request is bad</response>
        /// <response code="403">Returns Foribiden if user role isnt "Admin"</response>
        [HttpGet]
        [Route("/api/GetImageByName")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetImageByName([FromQuery] string name)
        {
            return Ok(await imageRepository.GetImage(name));
        }

        /// <summary>
        ///Get Image By Image Name
        /// </summary>
        /// <returns>Images</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /GetImages
        ///
        /// </remarks>
        /// <response code="200">Returns Image</response>
        /// <response code="400">If the Request is bad</response>
        /// <response code="403">Returns Foribiden if user role isnt "Admin"</response>
        [HttpGet]
        [Route("/api/GetImages")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetImages()
        {
            return Ok(await imageRepository.GetAll());
        }

        /// <summary>
        ///Get Image By Image Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Image</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /GetById:id
        ///
        /// </remarks>
        /// <response code="200">Returns Image</response>
        /// <response code="400">If the Request is bad</response>
        /// <response code="403">Returns Foribiden if user role isnt "Admin"</response>
        [HttpGet]
        [Route("GetById")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
