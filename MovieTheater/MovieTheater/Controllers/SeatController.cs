using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISeatRepository seatRepository;

        public SeatController(IMapper mapper, ISeatRepository seatRepository)
        {
            this.mapper = mapper;
            this.seatRepository = seatRepository;
        }




        /// <summary>
        /// Create a Seat. 
        /// </summary>
        /// <param name="seat"></param>
        /// <returns>Seat/</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /Create
        ///     {
        ///      "Reserverd":false,
        ///      "Location":int,
        ///      "ProjectionId":int
        ///     }
        /// </remarks>
        /// <response code="201">Returns Created Seat</response>
        /// <response code="400">If Request is Bad</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Seat seat)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await seatRepository.CreateAsync(seat);
            return CreatedAtAction("GetById", new { id = seat.Id }, mapper.Map<SeatDetailsDTO>(seat));
        }


        /// <summary>
        /// Create a Seats that fill a projection. 
        /// </summary>
        /// <param name="hallId"></param>
        /// <returns>Seat/</returns>
        /// <remarks>
        /// Sample request:
        ///     POST /CreateSeatsByHallCapacity/:id
        /// </remarks>
        /// <response code="201">Returns Created Seat</response>
        /// <response code="400">If Request is Bad</response>
        /// <response code="403">If Requesting user isn't a "Admin"</response>
        [HttpPost]
        [Route("CreateSeatsByHallCapacity")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateSeatsByHallCapacity([FromQuery] int hallId)



        {

            var existingSeats = await seatRepository.GetSeatsByProjectionId(hallId);
            if (existingSeats == null)
            {

                return BadRequest("This projection allready has seats");

            }
            await seatRepository.CreateSeatByProjectionCapacity(hallId);

            return RedirectToAction("GetAll");

        }
        /// <summary>
        /// Returns all Seats. 
        /// </summary>
        /// <returns>Seat</returns>
        /// <remarks>
        /// Sample request:
        ///     Get / GetAll
        /// </remarks>
        /// <response code="201">Returns Created Seat</response>
        /// <response code="400">If Request is Bad</response>
        /// <response code="403">If Requesting user isn't a "Admin"</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var seatModels = await seatRepository.GetAllAsync();


            return Ok(mapper.Map<List<SeatDetailsDTO>>(seatModels));
        }

        /// <summary>
        /// Returns Seats by Projection Id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<Seats></returns>
        /// <remarks>
        /// Sample request:
        ///   GET /GetSeatsByProjectionId/:id
        /// </remarks>
        /// <response code="200">Returns Created Seat</response>
        /// <response code="404">If No Seats Are FOund</response>
        [HttpGet]
        [Route("GetSeatsByProjectionId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetSeatsByProjectionId(int id)


        {

            var seatModels = await seatRepository.GetSeatsByProjectionId(id);


            return Ok(mapper.Map<List<SeatDetailsDTO>>(seatModels));
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var seat = await seatRepository.GetByIdAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<SeatDetailsDTO>(seat));
        }


        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, Seat seat)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seat.Id)
            {
                return BadRequest();
            }

            try
            {
                await seatRepository.UpdateAsync(id, seat);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(mapper.Map<SeatDetailsDTO>(seat));
        }



        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var seatDomainModel = await seatRepository.DeleteAsync(id);

            if (seatDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<SeatDetailsDTO>(seatDomainModel));
        }

    }
}
