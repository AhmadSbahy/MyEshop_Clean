using AutoMapper;
using FluentValidation;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.User.Validators;
using MyEshop_Clean.Application.Features.User.Requests.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDtoValidator(_userRepository);
            var validate = await validator.ValidateAsync(request.CreateUserDto);

            if (validate.IsValid)
            {
                var user = _mapper.Map<Domain.User>(request.CreateUserDto);
                user = await _userRepository.AddAsync(user);

                response.IsSuccess = true;
                response.Id = user.Id;
                response.Message = "کار بر با موفقیت ساخته شد";
            }
            else
            {
                response.ErroresList = validate.Errors.Select(p => p.ErrorMessage).ToList();
                response.IsSuccess = false;
                response.Message = "ساخت کاربر با شکست مواجه شد";
            }

            return response;
        }
    }
}
