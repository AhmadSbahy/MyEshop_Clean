using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Category.Validators;
using MyEshop_Clean.Application.Features.Category.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCategoryDtoValidator(_categoryRepository);
        var validate = await validator.ValidateAsync(request.UpdateCategoryDto);
        if (validate.IsValid)
        {
            var category = _mapper.Map<Domain.Category>(request.UpdateCategoryDto);
            await _categoryRepository.UpdateAsync(category);

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