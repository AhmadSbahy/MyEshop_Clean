using MediatR;
using MyEshop_Clean.Application.DTOs.Product;

namespace MyEshop_Clean.Application.Features.Product.Request.Queries
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
    }
}
