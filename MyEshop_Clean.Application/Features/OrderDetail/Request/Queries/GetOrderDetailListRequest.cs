using MediatR;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;

namespace MyEshop_Clean.Application.Features.OrderDetail.Request.Queries
{
    public class GetOrderDetailListRequest : IRequest<List<OrderDetailDto>>
    {
    }
}
