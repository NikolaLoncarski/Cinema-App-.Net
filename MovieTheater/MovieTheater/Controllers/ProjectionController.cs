using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models.DTO;
using MovieTheater.Models;
using MovieTheater.Repository;

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
            this.projectionRepository= projectionRepository;
        }


   


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projections = await projectionRepository.GetAllAsync();


            return Ok(mapper.Map<List<ProjectionDetailsDTO>>(projections));

        }
    }
}
