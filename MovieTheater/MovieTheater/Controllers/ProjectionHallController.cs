using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionHallController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProjectionHallRepository _projectionHallRepository;

        public ProjectionHallController(IMapper mapper, IProjectionHallRepository projectionHallRepository)
        {
            this.mapper = mapper;
            _projectionHallRepository = projectionHallRepository;
        }





        /// <summary>
        /// Searches for existing projection halls. 
        /// </summary>
        /// <returns>Projection Halls</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetAll
        ///     
        /// </remarks>
        /// <response code="200">Returns Ok Projection Hall List</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
    
        public async Task<IActionResult> GetAll()
        {
            var projectionHalls = await _projectionHallRepository.GetAllAsync();

            return Ok(projectionHalls);
        }
    }
}
