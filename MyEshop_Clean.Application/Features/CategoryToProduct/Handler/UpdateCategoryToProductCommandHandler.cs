using MediatR;
using MyEshop_Clean.Application.Features.CategoryToProduct.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Response;
using MyEshop_Clean.Application.DTOs.CategoryToProduct.Validators;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Handler
{
	public class UpdateCategoryToProductCommandHandler : IRequestHandler<UpdateCategoryToProductCommand, BaseCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryToProductRepository _categoryToProductRepository;

		public UpdateCategoryToProductCommandHandler(IMapper mapper, ICategoryToProductRepository categoryToProductRepository)
		{
			_mapper = mapper;
			_categoryToProductRepository = categoryToProductRepository;
		}

		public async Task<BaseCommandResponse> Handle(UpdateCategoryToProductCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateCategoryToProductDtoValidator();
			var validate = await validator.ValidateAsync(request.UpdateCategoryToProductDto);
			if (validate.IsValid)
			{
				var category = _mapper.Map<Domain.CategoryToProduct>(request.UpdateCategoryToProductDto); 
				await _categoryToProductRepository.UpdateAsync(category);

				response.Id = category.Id;
				response.IsSuccess = true;
				response.Message = "دسته بندی با موفقیت ویرایش شد";
			}
			else
			{
				response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
				response.IsSuccess = false;
				response.Message = "ویرایش دسته بندی با شکست مواجه شد";
			}
			return response;
		}
	}
}
