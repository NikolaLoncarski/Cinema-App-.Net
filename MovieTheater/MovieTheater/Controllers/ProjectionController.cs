﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models.DTO;
using MovieTheater.Models;
using MovieTheater.Repository;
using Microsoft.AspNetCore.Authorization;
using MovieTheater.Models.DTO.RequestDTOs;
using System.Security.Claims;

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

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateProjectionDTO createProjectionDTO)
        {

            var existingProje = await projectionRepository.CheckProjectionForDateAndHall(createProjectionDTO.ProjectionHallId, createProjectionDTO.DateAndTimeOfProjecton);

            if(existingProje == null )
            {

            var proj = mapper.Map<Projection>(createProjectionDTO);
         
                
                var newProjection = await projectionRepository.CreateAsync(proj);
       
                return RedirectToAction("GetById", new { id = newProjection.Id });
            }

            return BadRequest("This Projection allReady exists");

        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projections = await projectionRepository.GetAllAsync();


            return Ok(mapper.Map<List<ProjectionDetailsDTO>>(projections));

        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var projections = await projectionRepository.GetByIdAsync(id);

            if (projections == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map < ProjectionDetailsDTO >(projections));
        }
        [HttpGet]
        [Route("GetByMovieId")]
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
