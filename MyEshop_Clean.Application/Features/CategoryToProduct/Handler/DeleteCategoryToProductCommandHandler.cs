using AutoMapper;
using MyEshop_Clean.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;
using MediatR;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using MyEshop_Clean.Application.Exceptions;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Handler
{
	public class DeleteCategoryToProductCommandHandler : IRequestHandler<DeleteCategoryToProductCommand>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryToProductRepository _categoryToProductRepository;

		public DeleteCategoryToProductCommandHandler(IMapper mapper, ICategoryToProductRepository categoryToProductRepository)
		{
			_mapper = mapper;
			_categoryToProductRepository = categoryToProductRepository;
		}

		public async Task Handle(DeleteCategoryToProductCommand request, CancellationToken cancellationToken)
		{
			var category = await _categoryToProductRepository.GetAsync(request.Id);
			if (category == null)
			{
				throw new NotFoundException("جزییات دسته بندی پیدا نشد", typeof(Domain.Order));
			}

			await _categoryToProductRepository.DeleteAsync(category.Id);
		}
	}
}
