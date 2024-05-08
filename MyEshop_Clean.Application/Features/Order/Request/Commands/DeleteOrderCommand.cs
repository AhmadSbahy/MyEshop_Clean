using MediatR;

namespace MyEshop_Clean.Application.Features.Order.Request.Commands;

public class DeleteOrderCommand : IRequest
{
    public int Id  { get; set; }
}