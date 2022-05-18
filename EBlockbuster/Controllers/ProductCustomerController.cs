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
                CustomerId = p.CustomerId,
                PriceId = p.PriceId,
                Price = p.Price.Price,
            }));
        }

        [HttpPost]
        public IActionResult AddProductCustomer(ProductCustomerModel productCustomer)
        {
            if (ModelState.IsValid)
            {
                ProductCustomer newProductCustomer = new ProductCustomer()
                {
                    ProductId = productCustomer.ProductId,
                    CustomerId = productCustomer.CustomerId,
                    PriceId = productCustomer.PriceId
                };

                var result = _productCustomerRepository.Insert(newProductCustomer);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                  return CreatedAtRoute(nameof(GetByCustomer), new { id = result.Data.CustomerId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(ProductCustomerModel productCustomer)
        {
            var findResult = _productCustomerRepository.GetByProductCustomer(productCustomer.ProductId, productCustomer.CustomerId);

            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _productCustomerRepository.DeleteByProductCustomer(productCustomer.ProductId, productCustomer.CustomerId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(findResult.Data);
            }
        }
    }
}
