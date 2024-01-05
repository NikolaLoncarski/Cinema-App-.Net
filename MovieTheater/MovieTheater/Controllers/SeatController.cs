using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Repository;
using System;
using System.Globalization;

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
            this.seatRepository= seatRepository;
        }


     
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Seat seat)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            seatRepository.CreateAsync(seat);
            return CreatedAtAction("GetById", new { id = seat.Id }, mapper.Map<SeatDetailsDTO>(seat));
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seatModels = await seatRepository.GetAllAsync();


            return Ok(mapper.Map<List<SeatDetailsDTO>>(seatModels));
        }



        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
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
   
        public async Task<IActionResult> Update([FromRoute] int id, Seat seat)
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
                seatRepository.UpdateAsync(id, seat);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(mapper.Map<SeatDetailsDTO>(seat));
        }


  
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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
