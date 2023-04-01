using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Services.Interfaces;

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
    }
}
