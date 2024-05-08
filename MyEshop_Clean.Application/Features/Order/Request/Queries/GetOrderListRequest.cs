using MediatR;
using MyEshop_Clean.Application.DTOs.Order;

namespace MyEshop_Clean.Application.Features.Order.Request.Queries
{
    public class GetOrderListRequest : IRequest<List<OrderDto>>
    {

    }
}
