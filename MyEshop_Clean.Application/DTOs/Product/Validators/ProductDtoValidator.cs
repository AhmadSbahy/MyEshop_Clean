using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Product.Validators
{
    public class ProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly IProductRepository _productRepository;

        public ProductDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");
            RuleFor(p => p.Description)
                .NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

           
        }
    }
}
