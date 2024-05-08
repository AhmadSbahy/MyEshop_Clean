using MediatR;

namespace MyEshop_Clean.Application.Features.Category.Request.Commands;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}