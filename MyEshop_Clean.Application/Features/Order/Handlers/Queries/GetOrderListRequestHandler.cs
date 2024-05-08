using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Features.Order.Request.Queries;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Queries;

namespace MyEshop_Clean.Application.Features.Order.Handlers.Queries
{
    public class GetOrderListRequestHandler : IRequestHandler<GetOrderListRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<List<OrderDto>> Handle(GetOrderListRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(order);
        }
    }
}
