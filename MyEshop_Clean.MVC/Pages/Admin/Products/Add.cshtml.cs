using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.CategoryToProduct;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Pages.Admin.Products
{
    public class AddModel : PageModel
    {
	    private readonly IProductService _productService;
	    private readonly ICategoryService _categoryService;
		private readonly ICategoryToProductService _categoryToProductService;

		public AddModel(IProductService productService, ICategoryService categoryService, ICategoryToProductService categoryToProductService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_categoryToProductService = categoryToProductService;
		}

		[BindProperty]
		public CreateProductViewModel product { get; set; }

		[BindProperty]
	    public List<int> selectedGroups { get; set; }
	    public async Task OnGet()
	    {
		    product = new CreateProductViewModel()
		    {
				Categories = await _categoryService.GetCategory()
		    };
	    }

	    public async Task<IActionResult> OnPost(IFormFile file)
	    {
		    if (!ModelState.IsValid)
			    return Page();

		  var response = await _productService.CreateProduct(product);

		    if (file != null)
		    {
			    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
				    "wwwroot",
				    "images",
				    response.Data + Path.GetExtension(file.FileName));
			    using (var stream = new FileStream(filePath, FileMode.Create))
			    {
				    file.CopyTo(stream);
			    }
		    }

		    if (selectedGroups.Any() && selectedGroups.Count > 0)
		    {
			    foreach (int group in selectedGroups)
			    {
				    await _categoryToProductService.CreateCategoryToProduct(new CreateCategoryToProductViewModel()
				    {
					    CategoryId = group,
					    ProductId = product.Id
				    });
			    }
		    }
		    product = new CreateProductViewModel()
		    {
			    Categories = await _categoryService.GetCategory()
		    };
			return RedirectToPage("Index");
	    }
    }
}
