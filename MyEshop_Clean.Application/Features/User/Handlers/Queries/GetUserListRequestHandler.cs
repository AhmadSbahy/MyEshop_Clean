using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Application.Features.User.Requests.Queries;

namespace MyEshop_Clean.Application.Features.User.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest,List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var usersList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(usersList);
        }
    }
}
