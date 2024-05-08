using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Category.Validators
{
    public class CategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p=> p.Name)
                 .NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            RuleFor(p=> p.Description)
                 .NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            RuleFor(p => p.Id).GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    bool orderDetail = await _categoryRepository.IsExist(id);
                    return !orderDetail;
                }).WithMessage("{PropertyName} پیدا نشد");
        }
    }
}
