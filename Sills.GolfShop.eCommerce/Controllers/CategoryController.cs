using Microsoft.AspNetCore.Mvc;
using Sills.GolfShop.eCommerceAPI.Models;
using Sills.GolfShop.eCommerceAPI.Services;
using Sills.GolfShop.eCommerceAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Sills.GolfShop.eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase

    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<List<Categories>>> GetAllCategories([FromQuery] PaginationParameters param, [FromQuery] CategoryParameters categoryParams)
        {
            var query = _categoryService.GetAllCategoriesQuery();

 
            var pagedCategories = await query
                   .Where(c => c.DeletedAt == null)
                   .Skip((param.PageNumber - 1) * param.PageSize)
                   .Take(param.PageSize)
                   .ToListAsync();

            query = categoryParams.sortBy switch
            { 
                "name_desc" => query.OrderByDescending(p => p.Name),
                _ => query.OrderBy(p => p.Name)
            };

            return Ok(pagedCategories);
        }

        [HttpGet("{id}")]
        public ActionResult<Categories> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Categories> CreateCategory(Categories category)
        {
            var createdCategory = _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Categories category)
        {
            var existingCategory = _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryService.UpdateCategoryAsync(id, category);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

    }
}
