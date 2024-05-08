using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
	    private readonly IProductService _productService;

	    public IndexModel(IProductService productService)
	    {
		    _productService = productService;
	    }
	    public IEnumerable<ProductViewModel> Products { get; set; }
		public async Task OnGet()
		{
			Products = await _productService.GetProducts();
		}
    }
}
