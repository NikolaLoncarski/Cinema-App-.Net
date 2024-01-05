using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models.DTO;
using System.Security.Claims;

namespace MovieTheater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<IdentityUser> _userManager, ITokenRepository tokenRepository) {
            userManager = _userManager;
            this.tokenRepository = tokenRepository;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // Add roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                           Username = loginRequestDto.Username,
                            Roles= roles.ToList(),

                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }

        [HttpGet]
        [Authorize]
        [Route("GetCurrentUserId")]
        public async Task<IActionResult> GetCurrentUserId() {

            var idClaim = HttpContext.User.FindFirst("Id");

            if (idClaim == null)
            {
                return BadRequest("User ID claim not found");
            }

            if (!int.TryParse(idClaim.Value, out int id))
            {
                return BadRequest("User ID claim is not in the correct format");
            }

            return Ok(new { userId = id });
        }
    }
}
