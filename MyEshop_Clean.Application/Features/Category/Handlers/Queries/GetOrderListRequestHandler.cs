using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Features.Category.Request.Queries;
using MyEshop_Clean.Application.Features.Order.Request.Queries;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Queries;

namespace MyEshop_Clean.Application.Features.Category.Handlers.Queries
{
    public class GetOrderListRequestHandler : IRequestHandler<GetCategoryListRequest,List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetOrderListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(category);
        }
    }
}
