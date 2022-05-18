using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepository.Get(id);
            if (!product.Success)
            {
                return BadRequest(product.Message);
            }
            return Ok(new ProductModel()
            {
                ProductId = product.Data.ProductId,
                Name = product.Data.Name,
                Photo = product.Data.Photo,
                Description = product.Data.Description,
                CategoryId = product.Data.CategoryId
            });
        }

        [HttpGet]
        [Route("/api/[controller]/", Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAll();
            if (!products.Success)
            {
                return BadRequest(products.Message);
            }
            return Ok(products.Data.Select(p => new ProductModel()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Photo = p.Photo,
                Description = p.Description,
                CategoryId = p.CategoryId
            }));
        }

        [HttpGet]
        [Route("/api/[controller]/productcustomer/{id}", Name = "GetProductByCustomer")]
        public IActionResult GetProductByCustomer(int id)
        {
            var product = _productRepository.GetProductByCustomer(id);
            if (!product.Success)
            {
                return BadRequest(product.Message);
            }
            return Ok(product.Data.Select(p => new ProductModel()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Photo = p.Photo,
                Description = p.Description,
                CategoryId = p.CategoryId
            }));
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product()
                {
                    Name = product.Name,
                    Photo = product.Photo,
                    Description = product.Description,
                    CategoryId = product.CategoryId
                };

                var result = _productRepository.Insert(newProduct);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetProduct), new { id = result.Data.ProductId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductModel product)
        {
            if (ModelState.IsValid && product.ProductId > 0)
            {
                Product updateProduct = new Product()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Photo = product.Photo,
                    Description = product.Description,
                    CategoryId = product.CategoryId
                };

                var findResult = _productRepository.Get(product.ProductId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }
                var result = _productRepository.Update(updateProduct);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updateProduct);
                }
            }
            else
            {
                if (product.ProductId < 1)
                    ModelState.AddModelError("ProductId", "Invalid Product Id");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var findResult = _productRepository.Get(productId);

            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _productRepository.Delete(findResult.Data.ProductId);

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
