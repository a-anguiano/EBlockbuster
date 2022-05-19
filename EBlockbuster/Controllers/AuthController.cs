using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using EBlockbuster.Core.Interfaces;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public AuthController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        
        [HttpPost, Route("login")]
        public IActionResult Login(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var userObj = _loginRepository.GetByUserPass(user.Username, user.Password);

            if (!userObj.Success)
            {
                return BadRequest(userObj.Message);
            }
            if (user.Username == userObj.Data.Username && user.Password == userObj.Data.Password)
            {
                var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:2000",
                    audience: "http://localhost:2000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMonths(2),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new TokenModel()
                {
                    Token = tokenString,
                    LoginId = userObj.Data.LoginId,
                    SecurityLevelId = userObj.Data.SecurityLevelId,
                    Username = userObj.Data.Username,
                    Password = userObj.Data.Password
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
