using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetOrder();
        Task<OrderViewModel> GetProductDetail(int id);
        Task<Response<int>> CreateOrder(CreateOrderViewModel createOrderViewModel);
        Task<Response<int>> UpdateOrder(int id, UpdateOrderViewModel updateOrderViewModel);
        Task<Response<int>> DeleteOrder(int id);
    }
}
