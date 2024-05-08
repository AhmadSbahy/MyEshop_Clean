using MediatR;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Product.Request.Commands
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
