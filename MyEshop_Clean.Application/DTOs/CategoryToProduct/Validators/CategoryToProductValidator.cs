using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.CategoryToProduct.Validators
{
    public class CategoryToProductValidator : AbstractValidator<ICategoryToProductDto>
    {
        public CategoryToProductValidator()
        {
            RuleFor(p => p.ProductId)
                .GreaterThan(0).NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");
        }
    }
}
