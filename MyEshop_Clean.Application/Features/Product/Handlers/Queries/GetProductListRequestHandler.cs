using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.Product.Request.Queries;

namespace MyEshop_Clean.Application.Features.Product.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest,List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
