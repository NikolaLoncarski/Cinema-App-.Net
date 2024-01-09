using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models.DTO;
using MovieTheater.Repository;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatPositionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISeatPositionRepository seatPositionRepository;

        public SeatPositionController(IMapper mapper, ISeatPositionRepository seatPositionRepository)
        {
            this.mapper = mapper;
            this.seatPositionRepository = seatPositionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seatModels = await seatPositionRepository.GetAllAsync();


            return Ok(seatModels);
        }

    }
}
