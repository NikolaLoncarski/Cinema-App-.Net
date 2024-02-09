﻿using AutoMapper;
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
            string[] userRole = { "User" };
            registerRequestDto.Roles = userRole;
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
             
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
          
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);

            if (user != null  )
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
         
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {  id = Guid.Parse(user.Id),
                            JwtToken = jwtToken,
                           Username = loginRequestDto.Username,
                            Roles= roles.FirstOrDefault(),

                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        [Route("GetCurrentUserId")]
        public async Task<IActionResult> GetCurrentUserId() {

    


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            return Ok(userId);
        }
    }
}
