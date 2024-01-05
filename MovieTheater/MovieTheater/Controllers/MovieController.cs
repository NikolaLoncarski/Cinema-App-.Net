using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepository;

        public MovieController(IMapper mapper, IMovieRepository movieRepository)
        {
            this.mapper = mapper;
            this.movieRepository = movieRepository;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(int ImageId,[FromBody] Movie movie)
        {

            
            ImageId = ImageId;
            //await movieRepository.CreateAsync(movie);


            return Ok(ImageId);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var movies = await movieRepository.GetAllAsync(filterOn, filterQuery, sortBy,
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
