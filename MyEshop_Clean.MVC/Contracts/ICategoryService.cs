using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Category;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategory();
        Task<CategoryViewModel> GetCategoryDetail(int id);
        Task<Response<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel);
        Task<Response<int>> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryViewModel);
        Task<Response<int>> DeleteCategory(int id);
        
        Task<List<CategoryViewModel>> GetProductCategories(int productId);
        Task<IEnumerable<ShowCategoryViewModel>> GetCategoriesForShow();
    }
}
