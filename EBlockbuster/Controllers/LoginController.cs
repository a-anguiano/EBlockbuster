using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetLogin")]
        public IActionResult GetLogin(int id)
        {
            var login = _loginRepository.Get(id);
            if (!login.Success)
            {
                return BadRequest(login.Message);
            }
            return Ok(new LoginModel()
            {
                LoginId = login.Data.LoginId,
                Username = login.Data.Username,
                Password = login.Data.Password,
                SecurityLevelId = login.Data.SecurityLevelId
            });
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public IActionResult AddLogin(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Login newLogin = new Login()
                {
                    //LoginId?
                    Username = login.Username,
                    Password = login.Password
                    //sec lvl Id?
                };

                var result = _loginRepository.Insert(newLogin);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute("GetLogin", new { id = newLogin.LoginId }, newLogin);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Update(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Login updateLogin = new Login()
                {
                    LoginId = login.LoginId,
                    Username = login.Username,
                    Password = login.Password
                };

                var findResult = _loginRepository.Get(updateLogin.LoginId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _loginRepository.Update(updateLogin);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updateLogin);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
