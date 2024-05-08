using MediatR;
using MyEshop_Clean.Application.DTOs.Product;

namespace MyEshop_Clean.Application.Features.Product.Requests.Queries
{
    public class GetProductDetailRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
