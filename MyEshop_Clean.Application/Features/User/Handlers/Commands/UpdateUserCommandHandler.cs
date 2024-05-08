using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.User.Validators;
using MyEshop_Clean.Application.Features.User.Requests.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.User.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<BaseCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateUserDtoValidator(_userRepository);
        var validate = await validator.ValidateAsync(request.UpdateUserDto);

        if (validate.IsValid)
        {
            var user = _mapper.Map<Domain.User>(request.UpdateUserDto);
            await _userRepository.UpdateAsync(user);

            response.IsSuccess = true;
            response.Id = user.Id;
            response.Message = "کار بر با موفقیت ویرایش شد";
        }
        else
        {
            response.ErroresList = validate.Errors.Select(p => p.ErrorMessage).ToList();
            response.IsSuccess = false;
            response.Message = "ویرایش کاربر با شکست مواجه شد";
        }

        return response;
    }
}