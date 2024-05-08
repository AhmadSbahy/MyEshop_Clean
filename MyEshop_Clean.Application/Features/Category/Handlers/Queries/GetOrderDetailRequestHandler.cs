using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.Category.Requests.Queries;
using MyEshop_Clean.Application.Features.Order.Requests.Queries;
using MyEshop_Clean.Application.Features.OrderDetail.Requests.Queries;
using MyEshop_Clean.Application.Features.Product.Requests.Queries;

namespace MyEshop_Clean.Application.Features.Category.Handlers.Queries
{
    public class GetOrderDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest,CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<CategoryDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
