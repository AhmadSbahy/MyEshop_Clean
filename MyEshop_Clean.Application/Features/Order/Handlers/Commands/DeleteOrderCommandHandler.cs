using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Exceptions;
using MyEshop_Clean.Application.Features.Order.Request.Commands;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;

namespace MyEshop_Clean.Application.Features.Order.Handlers.Commands;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.Id);
        if (order == null)
        {
            throw new NotFoundException("جزییات فاکتوری پیدا نشد", typeof(Domain.Order));
        }

        await _orderRepository.DeleteAsync(order);
    }
}