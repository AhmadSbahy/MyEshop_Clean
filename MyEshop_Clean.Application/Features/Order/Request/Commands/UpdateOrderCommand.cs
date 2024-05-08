using MediatR;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Order.Request.Commands;

public class UpdateOrderCommand : IRequest<BaseCommandResponse>
{
    public UpdateOrderDto UpdateOrderDto { get; set; }
}