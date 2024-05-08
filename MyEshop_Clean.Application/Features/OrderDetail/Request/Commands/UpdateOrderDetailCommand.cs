using MediatR;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;

public class UpdateOrderDetailCommand : IRequest<BaseCommandResponse>
{
    public UpdateOrderDetailDto UpdateOrderDetailDto { get; set; }
}