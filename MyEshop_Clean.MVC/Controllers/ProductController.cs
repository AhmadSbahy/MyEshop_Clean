using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Controllers
{
	public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.GetProductDetail(id);
            var VM = new DetailViewModel
            {
                Product = product,
                Categories = product.CategoryToProducts.Select(c => c.Category).ToList()
            };
            return View(VM);
        }

        [Route("Group/{id}/{name}")]
        [HttpGet]
        public async Task<IActionResult> ShowProductByGroupId(int id, string name)
        {
	        var products = await _productService.GetProductsByCategoryId(id);
	        ViewData["GroupName"] = name;
	        return View(products);
        }

    }
}
