using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Services.Interfaces;

namespace Shop.Presentation.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(string categoryName)
        {
            var products = _productService.GetAll(categoryName);

            return View();
        }
    }
}
