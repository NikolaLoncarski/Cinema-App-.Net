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



        [HttpPost]
        //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateProjectionTypeDTO createProjectionTypeDto)
        {

            var projType = await projectionTypeRepository.CreateAsync(mapper.Map<ProjectionType>(createProjectionTypeDto));

            return CreatedAtAction("GetById", new { id = projType.Id });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var projectionTypeDto = await projectionTypeRepository.GetAllAsync();

            return Ok(mapper.Map<List<ProjectionTypeDTO>>(projectionTypeDto));
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetById")]
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
