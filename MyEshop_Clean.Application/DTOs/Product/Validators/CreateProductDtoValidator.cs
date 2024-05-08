using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            Include(new ProductDtoValidator(_productRepository));
            
            RuleFor(p => p.QuantityInStock)
                .GreaterThan(0).NotEmpty().NotNull().WithMessage("مقدار وارد شده نمیتواند صفر باشد");
            
         
            

            RuleFor(p => p.Price)
                .NotEmpty().NotNull().WithMessage("قیمتی برای محصول انتخاب کنید");
        }
    }
}
