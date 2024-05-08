using AutoMapper;
using MyEshop_Clean.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Handler
{
	public class GetCategoryToProductListRequestHandler : IRequestHandler<GetCategoryToProductListRequest, List<CategoryToProductDto>>
	{
		private readonly ICategoryToProductRepository _categoryToProductRepository;
		private readonly IMapper _mapper;

		public GetCategoryToProductListRequestHandler(ICategoryToProductRepository categoryToProductRepository, IMapper mapper)
		{
			_categoryToProductRepository = categoryToProductRepository;
			_mapper = mapper;
		}
		public async Task<List<CategoryToProductDto>> Handle(GetCategoryToProductListRequest request, CancellationToken cancellationToken)
		{
			var categoryToProducts = await _categoryToProductRepository.GetAllAsync();

			return _mapper.Map<List<CategoryToProductDto>>(categoryToProducts);
		}
	}
}
