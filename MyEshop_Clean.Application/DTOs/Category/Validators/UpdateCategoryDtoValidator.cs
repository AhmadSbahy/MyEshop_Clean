using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Clean.Application.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new CategoryDtoValidator(_categoryRepository));
        }
    }
}
