using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.OrderDetail.Requests.Queries;
using MyEshop_Clean.Application.Features.Product.Requests.Queries;

namespace MyEshop_Clean.Application.Features.OrderDetail.Handlers.Queries
{
    public class GetOrderDetailDetailRequestHandler : IRequestHandler<GetOrderDetailDetailRequest,OrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailDetailRequestHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailDto> Handle(GetOrderDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetAsync(request.Id);
            return _mapper.Map<OrderDetailDto>(orderDetail);
        }
    }
}
