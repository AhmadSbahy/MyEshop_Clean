using MediatR;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.Product;

namespace MyEshop_Clean.Application.Features.OrderDetail.Requests.Queries
{
    public class GetOrderDetailDetailRequest : IRequest<OrderDetailDto>
    {
        public int Id { get; set; }
    }
}
