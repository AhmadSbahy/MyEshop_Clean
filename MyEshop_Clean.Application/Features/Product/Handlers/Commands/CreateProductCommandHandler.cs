using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Product.Validators;
using MyEshop_Clean.Application.Features.Product.Request.Commands;
using MyEshop_Clean.Application.Response;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProductDtoValidator(_productRepository);
            var validate = await validator.ValidateAsync(request.CreateProductDto);
            if (validate.IsValid)
            {
                var product = _mapper.Map<Domain.Product>(request.CreateProductDto);
                var item = new Item()
                {
	                Price = request.CreateProductDto.Price,
	                QuantityInStock = request.CreateProductDto.QuantityInStock,
                };
				product = await _productRepository.AddAsync(product,item);
               
                response.Id = product.Id;
                response.IsSuccess = true;
                response.Message = "محصول با موفقیت ساخته شد";
            }
            else
            {
                response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
                response.IsSuccess = false;
                response.Message = "ایجاد محصول با شکست مواجه شد";
            }
            return response;
        }
    }
}
