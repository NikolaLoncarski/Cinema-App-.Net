using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateMovieDTO movieDTO)
        {

            var movie =   mapper.Map<Movie>(movieDTO);
            
          var newMovie =   await movieRepository.CreateAsync(movie);


            return Ok(mapper.Map<MovieDetailsDTO>(newMovie));
        }



        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? name,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var movies = await movieRepository.GetAllAsync(name, sortBy,
                    isAscending ?? true, pageNumber, pageSize);

   
            return Ok(mapper.Map<List<MovieDetailsDTO>>(movies));
            
        }

      
        [HttpGet]
        [Route("{id:int}")]
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



        [HttpPut]
        [Route("{id:int}")]
  
        public async Task<IActionResult> Update([FromRoute] int id, Movie movie)
        {

       
      

           var  movieModel= await movieRepository.UpdateAsync(id, movie);

            if (movieModel== null)
            {
                return NotFound();
            }


            return Ok(movieModel);
        }


      
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var movieModel = await movieRepository.DeleteAsync(id);

            if (movieModel == null)
            {
                return NotFound();
            }


            return Ok(movieModel);
        }
    }
}
