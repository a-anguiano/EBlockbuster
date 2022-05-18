using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdministratorRepository _adminRepo;

        public AdminController(IAdministratorRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        [HttpGet]
        [Route("/api/[controller]/{adminId}", Name = "GetAdministrator")]
        public IActionResult GetAdministrator(int adminId)
        {
            var result = _adminRepo.Get(adminId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/loginId/{loginId}", Name = "GetAdminByLoginId")]
        public IActionResult GetAdminByLoginId(int loginId)
        {
            var result = _adminRepo.GetAdminByLoginId(loginId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertAdministrator(AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                Administrator administrator = new Administrator
                {
                    FirstName = adminModel.FirstName,
                    LastName = adminModel.LastName,
                    LoginId = adminModel.LoginId
                };

                var result = _adminRepo.Insert(administrator);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetAdministrator), new { loginId = result.Data.LoginId, adminId = result.Data.AdminId }, result.Data);
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

        [HttpDelete("{adminId}")]
        public IActionResult DeleteAdministrator(int adminId)
        {
            var findResult = _adminRepo.Get(adminId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _adminRepo.Delete(adminId);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        [Route("/api/[controller]/")]
        public IActionResult UpdateAdministrator(AdminModel adminModel)
        {
            if (ModelState.IsValid && adminModel.AdminId > 0)
            {
                Administrator administrator = new Administrator
                {
                    AdminId = adminModel.AdminId,
                    FirstName = adminModel.FirstName,
                    LastName = adminModel.LastName,
                    LoginId = adminModel.LoginId
                };

                var findResult = _adminRepo.Get(administrator.AdminId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _adminRepo.Update(administrator);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (adminModel.AdminId < 1)
                    ModelState.AddModelError("AdminId", "Invalid Administrator ID");
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/", Name = "GetAllAdministrators")]
        public IActionResult GetAllAdmisitrators()
        {
            var administrators = _adminRepo.GetAll();
            if (!administrators.Success)
            {
                return BadRequest(administrators.Message);
            }
            return Ok(administrators.Data.Select(a => new AdminModel()
            {
                AdminId = a.AdminId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                LoginId = a.LoginId
            }));
        }
    }
}
