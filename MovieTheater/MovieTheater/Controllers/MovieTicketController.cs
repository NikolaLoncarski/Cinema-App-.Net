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
using System.Text.Json;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTicketController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMovieTicketRepository movieTicketRepository;
        private readonly ISeatRepository seatRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<MovieTicketController> _logger;

        public MovieTicketController(IMapper mapper, IMovieTicketRepository movieTicketRepository, UserManager<IdentityUser> _userManager
            , ISeatRepository seatRepository, ILogger<MovieTicketController> logger)
        {
            this.mapper = mapper;
            this.movieTicketRepository = movieTicketRepository;
            this._userManager = _userManager;
            this.seatRepository = seatRepository;
            _logger = logger;
        }


        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] MovieTicketRequestDTO movieTicketRequestDTO)
        {

            var checkSeatReservastion = await seatRepository.CheckIfSeatIsReserved(movieTicketRequestDTO.SeatId, movieTicketRequestDTO.Action);
            if (checkSeatReservastion != null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                movieTicketRequestDTO.UserId = Guid.Parse(userId);

                movieTicketRequestDTO.DateAndTimeOfPurchase = DateTime.UtcNow;
                var ticketRequest = mapper.Map<MovieTicket>(movieTicketRequestDTO);


                var ticket = await movieTicketRepository.CreateAsync(ticketRequest);
                return RedirectToAction("GetById", new { id = ticket.Id });
            }
            return BadRequest();







        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await movieTicketRepository.GetAllAsync();


            return Ok(mapper.Map<List<MovieTicketDetailsDTO>>(tickets));

        }

        [HttpGet]
        [Route("GetTicketByUserId")]
        [Authorize]
        public async Task<IActionResult> GetTicketByUserId()


        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(id);
            var tickets = await movieTicketRepository.GetTicketByUserId(userId);


            return Ok(mapper.Map<List<MovieTicketDetailsDTO>>(tickets));

        }


        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var movieTicket = await movieTicketRepository.GetByIdAsync(id);

            if (movieTicket == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<MovieTicketDetailsDTO>(movieTicket));
        }

        [HttpPut]
        [Route("DeleteTicket")]
   
        public async Task<IActionResult> DeleteTicket([FromBody] DeleteMovieTicketDTO deleteMovieTicketDTO)
        {

            var movieModel = await movieTicketRepository.DeleteAsync(deleteMovieTicketDTO.MovieTicketId);

            if (movieModel == null)
            {
                return NotFound();
            }

            var seatId = Guid.Parse(deleteMovieTicketDTO.SeatId);
             await seatRepository.ClearSeatReservation(seatId, deleteMovieTicketDTO.Action);


            return NoContent();
        }

    }
}
