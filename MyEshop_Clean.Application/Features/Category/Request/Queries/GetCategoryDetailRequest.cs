using MediatR;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Order;

namespace MyEshop_Clean.Application.Features.Category.Requests.Queries
{
    public class GetCategoryDetailRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
