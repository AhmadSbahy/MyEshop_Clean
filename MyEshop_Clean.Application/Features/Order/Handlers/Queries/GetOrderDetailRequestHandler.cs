using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.Order.Requests.Queries;
using MyEshop_Clean.Application.Features.OrderDetail.Requests.Queries;
using MyEshop_Clean.Application.Features.Product.Requests.Queries;

namespace MyEshop_Clean.Application.Features.Order.Handlers.Queries
{
    public class GetOrderDetailRequestHandler : IRequestHandler<GetOrderDetailRequest,OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<OrderDto> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
