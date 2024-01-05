using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Repository;

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
     
        public async Task<IActionResult> Create([FromBody] ProjectionType projectionType)
        {
            
            return Ok(await projectionTypeRepository.CreateAsync(projectionType));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll( )
        {
            var projectionTypeDto = await projectionTypeRepository.GetAllAsync();
    
            return Ok(mapper.Map<List<ProjectionTypeDTO>>(projectionTypeDto));
        }

    
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var projectionType =  await projectionTypeRepository.GetByIdAsync(id);
            if (projectionType == null)
            {
                return NotFound();
            }

            return Ok(projectionType);
        }

    



    
    }
}
