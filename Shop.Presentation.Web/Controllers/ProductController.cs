using Microsoft.AspNetCore.Mvc;
using Shop.BusinessLogic.Services.Interfaces;

namespace Shop.Presentation.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private const int UserId = 1;
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(string categoryName)
        {
            ViewBag.CategoryName = categoryName;

            var products = _productService.GetAll(categoryName);

            return View("Products", products);
        }

        [HttpGet]
        [Route("GetOrderedProducts")]
        public IActionResult GetOrderedProducts()
        {
            ViewBag.Title = "Ordered Products";

            var products = _productService.GetOrderedProducts(User.Identity.Name);

            return View("OrderedProducts", products);
        }

        [HttpGet]
        [Route("Buy")]
        public IActionResult Buy(int productId, string categoryName)
        {
            ViewBag.Title = "Products";
            ViewBag.CategoryName = categoryName;

            var products = _productService.GetAll(categoryName);

            _productService.Buy(productId, User.Identity.Name);

            return View("Products", products);
        }
    }
}
