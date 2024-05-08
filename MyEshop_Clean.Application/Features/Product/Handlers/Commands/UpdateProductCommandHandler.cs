using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Product.Validators;
using MyEshop_Clean.Application.Features.Product.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Product.Handlers.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateProductValidator(_productRepository);
        var validate = await validator.ValidateAsync(request.UpdateProductDto);
        if (validate.IsValid)
        {
            var product = _mapper.Map<Domain.Product>(request.UpdateProductDto); 
            await _productRepository.UpdateAsync(product,request.UpdateProductDto.ItemDto);

            response.Id = product.Id;
            response.IsSuccess = true;
            response.Message = "محصول با موفقیت ویرایش شد";
        }
        else
        {
            response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
            response.IsSuccess = false;
            response.Message = "ویرایش محصول با شکست مواجه شد";
        }
        return response;
    }
}