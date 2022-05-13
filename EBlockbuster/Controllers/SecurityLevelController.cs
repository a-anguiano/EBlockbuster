using EBlockbuster.Core.Interfaces.DAL;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityLevelController : Controller
    {
        private readonly ISecurityLevelRepository _securityLevelRepository;
        public SecurityLevelController(ISecurityLevelRepository securityLevelRepository)
        {
            _securityLevelRepository = securityLevelRepository;
        }


        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetSecurityLevelId")]
        public IActionResult GetSecurityLevelId(int id)
        {
            var securityLevel = _securityLevelRepository.Get(id);
            if (securityLevel == null)
            {
                return BadRequest(securityLevel.Message);
            }
            return Ok (new SecurityLevelModel()
            {
                SecurityLevelId = securityLevel.Data.SecurityLevelId,
                Level = securityLevel.Data.Level
            });
        }

        [HttpGet]
        [Route("/api/[controller]/", Name = "GetAllSecurityLevels")]
        public IActionResult GetAllSecurityLevel()
        {
            var securityLevel = _securityLevelRepository.GetAll();
            if (securityLevel == null)
            {
                return BadRequest(securityLevel.Message);
            }
            return Ok(securityLevel.Data.Select(s => new SecurityLevelModel()
            {
                SecurityLevelId = s.SecurityLevelId,
                Level = s.Level
            }));
        }

    }
}
