using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.User.Validators
{
    public class UserDtoValidator : AbstractValidator<IUserDto>
    {
        private readonly IUserRepository _userRepository;
        public UserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p.Email)
                .NotNull().WithMessage("{PropertyName} اجباری است")
                .EmailAddress().WithMessage("ایمیل وارد شده معتبر نمی باشد");

            RuleFor(p => p.Password)
                .NotNull().WithMessage("{PropertyName} اجباری است");

            
        }
    }
}
