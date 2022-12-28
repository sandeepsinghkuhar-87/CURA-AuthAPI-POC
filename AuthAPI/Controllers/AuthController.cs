using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthAPI.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService service, IConfiguration Configuration)
        {
            _service = service;
            _configuration = Configuration;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Authenticate(Login request)
        {
            var user = await _service.Authenticate(request.Username, request.Password);

            if (user == null)
                return BadRequest(new { message = "Invalid username or password." });

            var claims = new Dictionary<string, object>();
            claims.Add("SystemRegions", user.SystemRegion);
            claims.Add("SystemRoles", user.SystemRoles);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secret_key"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Claims = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Token = tokenString,
                Username = user.Username
            });
        }
    }
}
