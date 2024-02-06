using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.DTO;
using MovieTheater.Models.DTO.RequestDTOs;
using MovieTheater.Repository;
using System.Security.Claims;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public AuthController(IUserRepository userRepository, ILogger<AuthController> logger, IConfiguration configuration, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
         //   try
          //  {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var result = await _userRepository.Login(model);
                if (result.StatusCode == 0)
                    return BadRequest(result.StatusMessage);
                return Ok(result);
       /*     }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }*/
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegisterRequestDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _userRepository.Registration(model, Role.Admin);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(Register), model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        [Route("GetCurrentUserId")]
        public async Task<IActionResult> GetCurrentUserId() {

    


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            return Ok(userId);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(GetRefreshTokenViewModel model)
        {
            try
            {
                if (model is null)
                {
                    return BadRequest("Invalid client request");
                }

                var result = await _userRepository.GetRefreshToken(model);
                if (result.StatusCode == 0)
                    return BadRequest(result.StatusMessage);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return BadRequest("Invalid user name");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Ok("Success");
        }

        [Authorize]
        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
            return Ok("Success");
        }
    }
}
