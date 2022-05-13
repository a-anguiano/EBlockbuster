using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCustomerController : Controller
    {
        private readonly IProductCustomerRepository _productCustomerRepository;
        public ProductCustomerController(IProductCustomerRepository productCustomerRepository)
        {
            _productCustomerRepository = productCustomerRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetByCustomer")]
        public IActionResult GetByCustomer(int id)
        {
            var customer = _productCustomerRepository.GetByCustomerId(id);
            if (!customer.Success)
            {
                return BadRequest(customer.Message);
            }
            return Ok(customer.Data.Select(p => new ProductCustomerModel()
            {
                ProductId = p.ProductId,
                CustomerId = p.CustomerId
            }));
        }
    }
}
