using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models.Authorization.Dto;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration configuration;
        public AuthController(IAuthorizationService authorizationSerive, IConfiguration config)
        {
            _authorizationService = authorizationSerive;
            configuration = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login loginForm)
        {
            var loggedUser = await _authorizationService.Login(loginForm);
            if (loggedUser == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loggedUser.UserId.ToString()),
                new Claim(ClaimTypes.GivenName, loggedUser.Username),
                new Claim(ClaimTypes.Name, loggedUser.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Registration(Registration user)
        {
            var userName = user.Username.ToLower();

            if (await _authorizationService.UserExists(userName))
                return BadRequest("Użytkowik z tym nickiem już istnieje!");
                
            var createdUser = await _authorizationService.Register(user);
            
            return Ok(createdUser);
        }
        [HttpPost("logoff")]
        public async Task<IActionResult> LogOff(string userName)
        {
            return Ok(userName);
        }
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _authorizationService.GetUsers());
        }
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser(int userId)
        {
            return Ok(await _authorizationService.GetUser(userId));
        }
        
       
    }
}