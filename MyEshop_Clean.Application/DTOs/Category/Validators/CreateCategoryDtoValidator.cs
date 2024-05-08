using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Category.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new CategoryDtoValidator(_categoryRepository));
        }
    }
}
