using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Models.DTO.RequestDTOs;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionTypeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProjectionTypeRepository projectionTypeRepository;

        public ProjectionTypeController(IMapper mapper, IProjectionTypeRepository projectionTypeRepository)
        {
            this.mapper = mapper;
            this.projectionTypeRepository = projectionTypeRepository;
        }


        /// <summary>
        /// Create a A Projection Type. 
        /// </summary>
        /// <param name="createProjectionTypeDto"></param>
        /// <returns>MProjeciton Type.</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /Create
        /// </remarks>
        /// <response code="201">Returns the Created Movie Tick</response>
        /// <response code="403">Returns Forbidden if requesting user isn't a "Admin"</response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateProjectionTypeDTO createProjectionTypeDto)
        {

            var projType = await projectionTypeRepository.CreateAsync(mapper.Map<ProjectionType>(createProjectionTypeDto));

            return CreatedAtAction("GetById", new { id = projType.Id });
        }

        /// <summary>
        /// Returns a list of Projection Types.
        /// </summary>
        /// <returns>MProjeciton Type.</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetAll
        /// </remarks>
        /// <response code="200">Returns the Projection Type List</response>
        /// <response code="403">Returns Forbidden if requesting user isn't a "Admin"</response>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll()
        {
            var projectionTypeDto = await projectionTypeRepository.GetAllAsync();

            return Ok(mapper.Map<List<ProjectionTypeDTO>>(projectionTypeDto));
        }

        /// <summary>
        /// Create a A Projection Type. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MProjeciton Type.</returns>
        /// <remarks>
        /// Sample request:
        ///     Get / GetById/:id
        /// </remarks>
        /// <response code="200">Returns a Projection Type</response>
        /// <response code="403">Returns Forbidden if requesting user isn't a "Admin"</response>
        [HttpGet]
        [Route("GetById")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var projectionType = await projectionTypeRepository.GetByIdAsync(id);
            if (projectionType == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProjectionTypeDTO>(projectionType));
        }






    }
}
