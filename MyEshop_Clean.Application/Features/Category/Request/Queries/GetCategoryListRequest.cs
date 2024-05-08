using MediatR;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Order;

namespace MyEshop_Clean.Application.Features.Category.Request.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {

    }
}
