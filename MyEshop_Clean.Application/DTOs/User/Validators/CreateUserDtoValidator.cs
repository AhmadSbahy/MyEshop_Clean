using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.User.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new UserDtoValidator(_userRepository));
        }
    }
}
