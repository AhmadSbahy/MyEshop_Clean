using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Category.Validators;
using MyEshop_Clean.Application.DTOs.Order.Validators;
using MyEshop_Clean.Application.Features.Category.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryDtoValidator(_categoryRepository);
            var validate = await validator.ValidateAsync(request.CreateCategoryDto);
            if (validate.IsValid)
            {
                var category = _mapper.Map<Domain.Category>(request.CreateCategoryDto);
                category = await _categoryRepository.AddAsync(category);

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
