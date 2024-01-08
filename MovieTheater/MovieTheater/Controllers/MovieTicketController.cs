using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models.DTO;
using MovieTheater.Models;
using MovieTheater.Repository;
using MovieTheater.Models.DTO.RequestDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTicketController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMovieTicketRepository movieTicketRepository;


        public MovieTicketController(IMapper mapper,  IMovieTicketRepository movieTicketRepository)
        {
            this.mapper = mapper;
            this.movieTicketRepository = movieTicketRepository;
        }

     
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Create( [FromBody] MovieTicketRequestDTO movieTicketRequestDTO)
        {
  
            var ticketRequest = mapper.Map<MovieTicket>(movieTicketRequestDTO);


            var ticket =  await movieTicketRepository.CreateAsync(ticketRequest);
            return RedirectToAction("GetById", new { id = ticket.Id });
          
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets= await movieTicketRepository.GetAllAsync();


            return Ok(mapper.Map<List<MovieTicketDetailsDTO>>(tickets));

        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById( int id)
        {
            var movieTicket = await movieTicketRepository.GetByIdAsync(id);

            if (movieTicket == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<MovieTicketDetailsDTO>(movieTicket));
        }

    }
}
