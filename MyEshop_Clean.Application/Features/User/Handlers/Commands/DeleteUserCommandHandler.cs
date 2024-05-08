using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Exceptions;
using MyEshop_Clean.Application.Features.User.Requests.Commands;

namespace MyEshop_Clean.Application.Features.User.Handlers.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);
        if (user == null)
        {
            throw new NotFoundException("کاربری پیدا نشد", typeof(DeleteUserCommand));
        }

        await _userRepository.DeleteAsync(user);
    }
}