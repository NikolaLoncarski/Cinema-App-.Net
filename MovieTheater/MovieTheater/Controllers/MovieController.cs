using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Models.DTO.RequestDTOs;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepository;
        private readonly UserManager<IdentityUser> userManager;

        public MovieController(IMapper mapper, IMovieRepository movieRepository, UserManager<IdentityUser> userManager)
        {
            this.mapper = mapper;
            this.movieRepository = movieRepository;
            this.userManager = userManager;
        }

        /// <summary>
        /// Creates a New Movie.
        /// </summary>
        /// <param name="MovieDTO"></param>
        /// <returns>Creates a New Movie</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Create
        ///     {
        ///       "name": "string",
        ///        "director": "string",
        ///        "leadActor": "string",
        ///"genre": "string",
        ///"duration": 0,
        ///"distributer": "string",
        ///"countryOfOrigin": "string",
        ///"yearOfRelease": 0,
        ///"description": "string",
        ///"imageId": 0
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created Movie</response>
        /// <response code="400">If the Request is bad</response>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create([FromBody] CreateMovieDTO movieDTO)
        {

            var movie = mapper.Map<Movie>(movieDTO);

            var newMovie = await movieRepository.CreateAsync(movie);


            return Ok(mapper.Map<MovieDetailsDTO>(newMovie));
        }



        /// <summary>
        /// Searches for an existing movie.
        /// </summary>
        /// <returns>An Existing movie.</returns>
        /// <remarks>
        /// Sample request:
        ///    get/Movie?name=lord&sortBy=name&isAscending=true&pageNumber=1&pageSize=10
        /// </remarks>
        /// <response code="200">Returns a movie if it exists in the database</response>
        /// <response code="404">If movie is not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] string? name,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var movies = await movieRepository.GetAllAsync(name, sortBy,
                    isAscending ?? true, pageNumber, pageSize);


            return Ok(mapper.Map<List<MovieDetailsDTO>>(movies));

        }

        /// <summary>
        /// Gets a Movie By Movie Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie.</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /GetById/:Id
        /// </remarks>
        /// <response code="200">Returns the newly created Movie</response>
        /// <response code="404">If No Movie Exists with that Id</response>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var movie = await movieRepository.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<MovieDetailsDTO>(movie));
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> YourAction()
        {

            var users = await userManager.Users.ToListAsync();



            return Ok(users);
        }


        /// <summary>
        /// Movie Statistics
        /// </summary>
        /// <returns>Statistics</returns>
        /// <remarks>
        /// <response code="200">Returns the newly created Movie</response>
        /// <response code="404">If No Movie Exists with that Id</response>
        [HttpGet]
        [Route("Statistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovieStatistics([FromQuery] string? name,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {

            var stats = await movieRepository.GetAllStatisticsAsync(name, sortBy,
                    isAscending ?? true, pageNumber, pageSize);



            return Ok(stats);
        }


        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <returns>Movie</returns>
        /// Sample request:
        ///     POST /Update/:Id
        /// </remarks>
        /// <response code="202">Returns Accepted if movie is successfully updated</response>
        /// <response code="404">If No Movie Exists with that Id</response>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, Movie movie)
        {




            var movieModel = await movieRepository.UpdateAsync(id, movie);

            if (movieModel == null)
            {
                return NotFound();
            }


            return Accepted(movieModel);
        }


        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <returns>Movie</returns>
        /// Sample request:
        ///     POST /Delete/:Id
        /// </remarks>
        /// <response code="202">Returns Accepted if movie is successfully Deleted</response>
        /// <response code="404">If No Movie Exists with that Id</response>
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var movieModel = await movieRepository.DeleteAsync(id);

            if (movieModel == null)
            {
                return NotFound();
            }


            return Accepted(movieModel);
        }
    }
}
