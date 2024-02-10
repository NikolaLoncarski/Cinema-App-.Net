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
    public class ProjectionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProjectionRepository projectionRepository;

        public ProjectionController(IMapper mapper, IProjectionRepository projectionRepository)
        {
            this.mapper = mapper;
            this.projectionRepository = projectionRepository;
        }

        /// <summary>
        /// Creates a Projection and coresponding seats for the projection hall size. 
        /// </summary>
        /// <param name="createProjectionDTO">createProjectionDTO</param>
        /// <returns>Projeciton</returns>
        /// <remarks>
        /// Sample request:
        ///     Post /Create
        ///     {
        ///     "MovieId":int,
        ///     "projectionHallId":int,
        ///     "projectionTypeId":int,
        ///     "price":decimal
        ///     
        ///            }
        ///     
        /// </remarks>
        /// <response code="201">Returns Created Projection</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="403">Forbiden if users role isn't "Admin".</response>
        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateProjectionDTO createProjectionDTO)
        {

            var existingProje = await projectionRepository.CheckProjectionForDateAndHall(createProjectionDTO.ProjectionHallId, createProjectionDTO.DateAndTimeOfProjecton);

            if (existingProje == null)
            {

                var proj = mapper.Map<Projection>(createProjectionDTO);


                var newProjection = await projectionRepository.CreateAsync(proj);

                return RedirectToAction("GetById", new { id = newProjection.Id });
            }

            return BadRequest("This Projection allReady exists");

        }


        /// <summary>
        /// Creates a Projection and coresponding seats for the projection hall size. 
        /// </summary>
        /// <returns>Projeciton</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetAll
        ///     
        /// </remarks>
        /// <response code="200">Returns Projections</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var projections = await projectionRepository.GetAllAsync();


            return Ok(mapper.Map<List<ProjectionDetailsDTO>>(projections));

        }

        /// <summary>
        /// Searches for a projection for a coresponding Id. 
        /// </summary>
        /// <param name="id">cId</param>
        /// <returns>Projeciton</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetById/:id
        /// </remarks>
        /// <response code="200">Returns  Projection</response>
        /// <response code="404">If there are no projections with that Id.</response>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var projections = await projectionRepository.GetByIdAsync(id);

            if (projections == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<ProjectionDetailsDTO>(projections));
        }

        /// <summary>
        /// Searches for a projection with the movie ID. 
        /// </summary>
        /// <param name="id">cId</param>
        /// <returns>Projecitons</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetByMovieId/:id
        /// </remarks>
        /// <response code="200">Returns  Projections</response>
        /// <response code="404">If there are no projections with that movie Id .</response>
        [HttpGet]
        [Route("GetByMovieId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByMovieId(int id)
        {
            var projections = await projectionRepository.GetByMovieIdAsync(id);

            if (projections == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<List<ProjectionDetailsDTO>>(projections));
        }
    }
}
