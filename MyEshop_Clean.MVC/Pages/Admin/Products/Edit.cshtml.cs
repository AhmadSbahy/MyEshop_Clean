using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.CategoryToProduct;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
	    private readonly IProductService _productService;
	    private readonly ICategoryService _categoryService;
	    private readonly ICategoryToProductService _categoryToProductService;
	    private readonly IMapper _mapper;

	    public EditModel(IProductService productService, ICategoryService categoryService, ICategoryToProductService categoryToProductService, IMapper mapper)
	    {
		    _productService = productService;
		    _categoryService = categoryService;
		    _categoryToProductService = categoryToProductService;
		    _mapper = mapper;
	    }
		[BindProperty]
	    public UpdateProductViewModel product { get; set; }

		[BindProperty]
		public List<int> selectedGroups { get; set; }

		public async Task OnGet(int id)
		{
			product = _mapper.Map<UpdateProductViewModel>(await _productService.GetProductDetail(id));
			product.Categories =  await _categoryService.GetCategory();
	    }

	    public async Task<IActionResult> OnPost(IFormFile? file)
		{
			if (!ModelState.IsValid)
				return Page();
			var response = await _productService.UpdateProduct(product.Id,product);
			
			if (file != null)
		    {
			    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{product.Id}.jpg");
			    if (System.IO.File.Exists(imagePath))
			    {
				    System.IO.File.Delete(imagePath);
			    }
			    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
				    "wwwroot",
				    "images",
				    product.Id + Path.GetExtension(file.FileName));
			    using (var stream = new FileStream(filePath, FileMode.Create))
			    {
				    file.CopyTo(stream);
			    }
			}

			foreach (var categoryToProductViewModel in (await _categoryToProductService.GetCategoryToProduct())
			         .Where(x=>x.ProductId == product.Id).ToList())
			{
				await _categoryToProductService.DeleteCategoryToProduct(categoryToProductViewModel.Id);
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
			return RedirectToPage("Index");
	    }
    }
}
