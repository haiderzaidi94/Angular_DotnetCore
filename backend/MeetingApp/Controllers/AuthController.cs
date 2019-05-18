using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Data;
using MeetingApp.DTOs;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO userdto)
        {

            userdto.Username = userdto.Username.ToLower();
            if (await _repo.UserExists(userdto.Username))
                return BadRequest("User Already Exists");

            var userToCreate = new Users()
            {
                Name = userdto.Username
            };

            var createuser = await _repo.Register(userToCreate, userdto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(UserLoginDTO login)
        {
            var user = await _repo.Login(login.username, login.Password);
            if (user == null)
                return Unauthorized();

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").ToString()));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return Ok(new { token = tokenHandler.WriteToken(token) });

        }
    }
}
