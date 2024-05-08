using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Category.Validators;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;
using MyEshop_Clean.Application.DTOs.CategoryToProduct.Validators;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Handler
{
	public class CreateCategoryToProductCommandHandler : IRequestHandler<CreateCategoryToProductCommand, BaseCommandResponse>
	{
		private readonly ICategoryToProductRepository _categoryToProductRepository;
		private readonly IMapper _mapper;

		public CreateCategoryToProductCommandHandler(ICategoryToProductRepository categoryToProductRepository, IMapper mapper)
		{
			_categoryToProductRepository = categoryToProductRepository;
			_mapper = mapper;
		}

		public async Task<BaseCommandResponse> Handle(CreateCategoryToProductCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateCategoryToProductDtoValidator();
			var validate = await validator.ValidateAsync(request.CreateCategoryToProductDto);
			if (validate.IsValid)
			{
				var category = _mapper.Map<Domain.CategoryToProduct>(request.CreateCategoryToProductDto);
				category = await _categoryToProductRepository.AddAsync(category);

				response.Id = category.Id;
				response.IsSuccess = true;
				response.Message = "دسته بندی با موفقیت ساخته شد";
			}
			else
			{
				response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
				response.IsSuccess = false;
				response.Message = "ایجاد دسته بندی با شکست مواجه شد";
			}
			return response;
		}
	}
}
