using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Queries;

namespace MyEshop_Clean.Application.Features.OrderDetail.Handlers.Queries
{
    public class GetOrderDetailListRequestHandler : IRequestHandler<GetOrderDetailListRequest,List<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailListRequestHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailDto>> Handle(GetOrderDetailListRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<List<OrderDetailDto>>(orderDetail);
        }
    }
}
