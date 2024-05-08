using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.CategoryToProduct;

namespace MyEshop_Clean.MVC.Contracts
{
	public interface ICategoryToProductService
	{
		Task<List<CategoryToProductViewModel>> GetCategoryToProduct();
		Task<CategoryToProductViewModel> GetCategoryDetailToProduct(int id);
		Task<Response<int>> CreateCategoryToProduct(CreateCategoryToProductViewModel createCategoryToProductView);
		Task<Response<int>> UpdateCategoryToProduct(int id, UpdateCategoryToProductViewModel createCategoryToProductView);
		Task<Response<int>> DeleteCategoryToProduct(int id);
	}
}	
