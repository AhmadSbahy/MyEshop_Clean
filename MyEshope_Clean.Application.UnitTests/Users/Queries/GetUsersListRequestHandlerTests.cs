using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Application.Features.User.Handlers.Queries;
using MyEshop_Clean.Application.Features.User.Requests.Queries;
using MyEshop_Clean.Application.Profiles;
using MyEshop_Clean.Application.UnitTests.Mocks;
using Shouldly;

namespace MyEshop_Clean.Application.UnitTests.Users.Queries
{
    public class GetUsersListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public GetUsersListRequestHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _userRepository = MockUserRepository.GetUserRepositoryMock();
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetUsersListTest()
        {
            var handler = new GetUserListRequestHandler(_userRepository.Object, _mapper);
            var result = await handler.Handle(new GetUserListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<UserDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
