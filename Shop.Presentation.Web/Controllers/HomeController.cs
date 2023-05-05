using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Shop.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ISingletonGuidCreator singletonGuidCreator1;
        private readonly ISingletonGuidCreator singletonGuidCreator2;
        private readonly IScopedGuidCreator scopedGuidCreator1;
        private readonly IScopedGuidCreator scopedGuidCreator2;
        private readonly ITransientGuidCreator transientGuidCreator1;
        private readonly ITransientGuidCreator transientGuidCreator2;

        public HomeController(
            ILogger<HomeController> logger,
            ISingletonGuidCreator singletonGuidCreator1,
            ISingletonGuidCreator singletonGuidCreator2,
            IScopedGuidCreator scopedGuidCreator1,
            IScopedGuidCreator scopedGuidCreator2,
            ITransientGuidCreator transientGuidCreator1,
            ITransientGuidCreator transientGuidCreator2
            )
        {
            this.logger = logger;
            this.singletonGuidCreator1 = singletonGuidCreator1;
            this.singletonGuidCreator2 = singletonGuidCreator2;
            this.scopedGuidCreator1 = scopedGuidCreator1;
            this.scopedGuidCreator2 = scopedGuidCreator2;
            this.transientGuidCreator1 = transientGuidCreator1;
            this.transientGuidCreator2 = transientGuidCreator2;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetGuids()
        {
            logger.LogWarning($"Singleton: {singletonGuidCreator1.GetGuid()} = = = {singletonGuidCreator2.GetGuid()}");
            logger.LogWarning($"Scoped: {scopedGuidCreator1.GetGuid()} = = = {scopedGuidCreator2.GetGuid()}");
            logger.LogWarning($"Transient: {transientGuidCreator1.GetGuid()} = = = {transientGuidCreator2.GetGuid()}");

            return Content($"Singleton: {singletonGuidCreator1.GetGuid()} = = = {singletonGuidCreator2.GetGuid()}\nScoped: {scopedGuidCreator1.GetGuid()} = = = {scopedGuidCreator2.GetGuid()}\nTransient: {transientGuidCreator1.GetGuid()} = = = {transientGuidCreator2.GetGuid()}");
        }
    }
}
