using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;

namespace Shop.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICategoryService categoryService)
        {
            categoryService.Create(
                new Category
                {
                    Id = 1,
                    Name = "Mobiles",
                    Description = "Mobiles Description"
                });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
