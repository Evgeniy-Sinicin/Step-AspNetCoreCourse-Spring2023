using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using Shop.Presentation.Web.Areas.Identity.Data;

namespace Shop.Presentation.Web.Controllers
{
    [Route("Category")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();

            return View("Categories", categories);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(string categoryName)
        {
            var category = _categoryService.Get(categoryName);

            return View("Category", category);
        }

        [HttpPost]
        [Route("CreateOrUpdate")]
        public IActionResult CreateOrUpdate(Category category)
        {
            if (category.Id == 0)
            {
                _categoryService.Create(category);
            }
            else
            {
                _categoryService.Update(category);
            }

            return Redirect("GetAll");
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);

            return Redirect("GetAll");
        }
    }
}
