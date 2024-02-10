using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Models.DTO.RequestDTOs;
using System.Security.Claims;

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


        /// <summary>
        /// Create a Movie Ticket. 
        /// </summary>
        /// <param name="movieTicketRequestDTO"></param>
        /// <returns>MovieTickets.</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /Create
        /// </remarks>
        /// <response code="200">Returns the Created Movie Ticket</response>
        /// <response code="400">If Request is Bad</response>
        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "User, Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Gets All MovieTickets
        /// </summary>
        /// <returns>MovieTickets</returns>
        /// <remarks>
        /// Sample request:
        ///    Get /GetAll
        /// </remarks>
        /// <response code="200">Returns All Movie Ticket</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await movieTicketRepository.GetAllAsync();


            return Ok(mapper.Map<List<MovieTicketDetailsDTO>>(tickets));

        }


        /// <summary>
        /// Searches for Movie Tickets that contain the user id that is using the URL. 
        /// </summary>
        /// <returns>MovieTickets</returns>
        /// <response code="200">Returns Movie Tickets</response>
        [HttpGet]
        [Route("GetTicketByUserId")]
        [Authorize(Roles = "Admin,User")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> GetTicketByUserId()


        {

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(id);
            var tickets = await movieTicketRepository.GetTicketByUserId(userId);


            return Ok(mapper.Map<List<MovieTicketDetailsDTO>>(tickets));

        }


        /// <summary>
        /// Searches for Movie Ticket by movieTicketID. 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>MovieTickets</returns>
        /// <remarks>
        /// Sample request:
        ///     Get /GetById/:id
        /// </remarks>
        /// <response code="200">Returns Movie Tickets</response>
        /// <response code="404">No tickets found.</response>
        [HttpGet]
        [Route("GetById")]
        [Authorize(Roles = "Admin,User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var movieTicket = await movieTicketRepository.GetByIdAsync(id);

            if (movieTicket == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<MovieTicketDetailsDTO>(movieTicket));
        }

        /// <summary>
        /// Searches for Movie Ticket by movieTicketID. 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>MovieTickets</returns>
        /// <remarks>
        /// Sample request:
        ///     Put /DeleteTicket
        /// </remarks>
        /// <response code="204">Returns No content</response>
        /// <response code="404">No tickets found.</response>
        [HttpDelete]
        [Route("DeleteTicket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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
