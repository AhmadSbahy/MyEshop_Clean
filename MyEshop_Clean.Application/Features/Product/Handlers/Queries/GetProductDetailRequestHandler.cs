using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Features.Product.Requests.Queries;

namespace MyEshop_Clean.Application.Features.Product.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest,ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
