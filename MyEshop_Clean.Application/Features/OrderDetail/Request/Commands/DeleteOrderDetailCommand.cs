using MediatR;

namespace MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;

public class DeleteOrderDetailCommand : IRequest
{
    public int Id { get; set; }
}