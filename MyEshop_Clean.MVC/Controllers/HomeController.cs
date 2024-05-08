using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.MVC.Base;
using MyEshop_Clean.MVC.Contracts;

namespace MyEshop_Clean.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
	        return View();
        }
	}
}
