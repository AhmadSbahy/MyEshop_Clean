using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MyEshop_Clean.Application.DTOs.CategoryToProduct.Validators
{
    public class CreateCategoryToProductDtoValidator : AbstractValidator<CreateCategoryToProductDto>
    {
        public CreateCategoryToProductDtoValidator()
        {
            Include(new CategoryToProductValidator());
        }
    }
}
