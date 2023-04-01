using Microsoft.AspNetCore.Mvc;

namespace Shop.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
