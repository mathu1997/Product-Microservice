using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using AuthMicroservice.Models;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace AuthMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        
        private static List<UserInfo> user;
        private IConfiguration _config;
        public int success=0;
        public string message;

        public AuthController(IConfiguration config)
        {
            _config = config;
            user = new List<UserInfo>()
            {
                new UserInfo {UserId=1001, Username="Thiru", Password="thiru123"},
                new UserInfo {UserId=1002, Username="Roshan", Password="roshan123"},
                new UserInfo {UserId=1003, Username="Haripriya", Password="haripriya123"},
                new UserInfo {UserId=1004, Username="Mathumitran", Password="mathumitran123"},
                new UserInfo {UserId=1005, Username="Sharmila", Password="sharmila123"}

            };
            
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserInfo login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {

                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, User_id = user.UserId,userName= user.Username });
            }

            

            return response;
        }

        private string GenerateJSONWebToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DarkSecretInTheLight"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserInfo AuthenticateUser(UserInfo login)
        {
         // UserInfo user = null;
            UserInfo vuser = user.FirstOrDefault(c => c.Username == login.Username && c.Password == login.Password);
            return vuser;
        }
    }
}
