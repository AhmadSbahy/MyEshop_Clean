using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Order;
using MyEshop_Clean.MVC.Models.OrderDetail;

namespace MyEshop_Clean.MVC.Contracts
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailViewModel>> GetOrderDetail();
        Task<OrderDetailViewModel> GetOrderDetailDetail(int id);
        Task<Response<int>> CreateOrderDetail(CreateOrderDetailViewModel createOrderDetailViewModel);
        Task<Response<int>> UpdateOrderDetail(int id, UpdateOrderDetailViewModel updateOrderDetailViewModel);
        Task<Response<int>> DeleteOrderDetail(int id);
    }
}
