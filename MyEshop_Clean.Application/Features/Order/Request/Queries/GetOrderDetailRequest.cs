using MediatR;
using MyEshop_Clean.Application.DTOs.Order;

namespace MyEshop_Clean.Application.Features.Order.Requests.Queries
{
    public class GetOrderDetailRequest : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
