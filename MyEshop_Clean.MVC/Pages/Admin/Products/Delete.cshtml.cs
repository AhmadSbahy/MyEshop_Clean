using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Pages.Admin.Products
{
    public class DeleteModel : PageModel
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly ICategoryToProductService _categoryToProductService;
		private readonly IMapper _mapper;

		public DeleteModel(IProductService productService, ICategoryService categoryService, ICategoryToProductService categoryToProductService, IMapper mapper)
		{
			_productService = productService;
			_categoryService = categoryService;
			_categoryToProductService = categoryToProductService;
			_mapper = mapper;
		}
		[BindProperty]
		public ProductViewModel Product { get; set; }
		public async Task OnGet(int id)
        {
	        Product = await _productService.GetProductDetail(id);
		}

		public async Task<IActionResult> OnPost()
		{
			await _productService.DeleteProduct(Product.Id);
			return RedirectToPage("Index");
		}
    }
}
