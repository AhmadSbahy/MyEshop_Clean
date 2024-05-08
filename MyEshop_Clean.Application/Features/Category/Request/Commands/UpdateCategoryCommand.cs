using MediatR;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Category.Request.Commands;

public class UpdateCategoryCommand : IRequest<BaseCommandResponse>
{
    public UpdateCategoryDto UpdateCategoryDto { get; set; }
}