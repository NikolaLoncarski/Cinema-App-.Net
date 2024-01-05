using AutoMapper;
using Microsoft.AspNetCore.Http;
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





        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var projectionHalls = await _projectionHallRepository.GetAllAsync();

            return Ok(projectionHalls);
        }
    }
}
