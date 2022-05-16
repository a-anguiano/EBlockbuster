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
        [Route("/api/[controller]/{loginId}", Name = "GetLogin")]
        public IActionResult GetLogin(int loginId)
        {
            var login = _loginRepository.Get(loginId);

            if (login.Success)
            {
                return Ok(login.Data);
            }
            else
            {
                return NotFound(login.Message);
            }
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public IActionResult AddLogin(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Login newLogin = new Login()
                {
                    Username = login.Username,
                    Password = login.Password,
                    SecurityLevelId = 2
                };

                var result = _loginRepository.Insert(newLogin);
                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetLogin), new { loginId = result.Data.LoginId }, result.Data);

                }
                else
                {
                    return BadRequest(result.Message);
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
