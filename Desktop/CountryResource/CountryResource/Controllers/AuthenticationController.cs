using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CountryResource.DomainModels;
using CountryResource.Entities;
using CountryResource.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CountryResource.Controllers
{
    [Route("api/[controller]")]
   
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserManager _userManager;

        public AuthenticationController(IUserManager userManager,  IConfiguration config)
        {
            _userManager = userManager;
           
            _config = config;
        }

        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return base.BadRequest(new ApiResponse<UserModel>()
                {
                    Data = user,
                    Message = "Invalid input",
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
            var result = await _userManager.CreateUser(user);
            if (result.Status)
            {
                return Ok(new ApiResponse<UserModel>()
                {                    
                    Message = "Successful",
                    StatusCode = HttpStatusCode.OK
                });
            }
            return BadRequest(new ApiResponse<UserModel>()
            {
                Data = user,
                Message = "Internal server erroe",
                StatusCode = HttpStatusCode.InternalServerError
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel obj)
        {

            var user = await _userManager.Verifyuser(obj.Email, obj.password);
            if (user == null) {
                return Unauthorized(new ApiResponse<UserModel>()
                {
                   
                    Message = "User not authorized",
                    StatusCode = HttpStatusCode.Unauthorized
                });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);        
               
          
           
            return Ok(new { tokenString });

        }

    }
}