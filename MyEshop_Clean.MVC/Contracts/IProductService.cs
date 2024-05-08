using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Product;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProductDetail(int id);
        Task<Response<int>> CreateProduct(CreateProductViewModel createProductViewModel);
        Task<Response<int>> UpdateProduct(int id, UpdateProductViewModel updateProductViewModel);
        Task<Response<int>> DeleteProduct(int id);

        Task<List<ProductViewModel>> GetProductsByCategoryId(int id);
    }
}
