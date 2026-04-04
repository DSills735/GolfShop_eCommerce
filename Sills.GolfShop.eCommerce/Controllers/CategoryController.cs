using Microsoft.AspNetCore.Mvc;
using Sills.GolfShop.eCommerceAPI.Models;
using Sills.GolfShop.eCommerceAPI.Services;

namespace Sills.GolfShop.eCommerceAPI.Controllers
{
    public class CategoryController(ICategoryService categoryService) : ControllerBase

    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet]
        public ActionResult<List<Categories>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
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
