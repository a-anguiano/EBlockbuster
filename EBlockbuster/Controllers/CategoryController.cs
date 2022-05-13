using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBlockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]   //, Authorize
        [Route("/api/[controller]/{categoryId}", Name = "GetCategory")]
        public IActionResult GetCategory(int categoryId)
        {
            var result = _categoryRepo.Get(categoryId);

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
        public IActionResult AddCategory(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                   
                    
                };

                var result = _categoryRepo.Insert(newCategory);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetCategory), new { id = result.Data.CategoryId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel category)
        {
            if (ModelState.IsValid && category.CategoryId > 0)
            {
                Category updateCategory = new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                };

                var findResult = _categoryRepo.Get(category.CategoryId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }
                var result = _categoryRepo.Update(updateCategory);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updateCategory);
                }
            }
            else
            {
                if (category.CategoryId < 1)
                    ModelState.AddModelError("ProductId", "Invalid Product Id");
                return BadRequest(ModelState);
            }
        }
    }
}
