using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Exceptions;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;

namespace MyEshop_Clean.Application.Features.OrderDetail.Handlers.Commands;

public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IMapper _mapper;

    public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetAsync(request.Id);
        if (orderDetail == null)
        {
            throw new NotFoundException("جزییات فاکتوری پیدا نشد", typeof(Domain.Product));
        }

        await _orderDetailRepository.DeleteAsync(orderDetail);
    }
}