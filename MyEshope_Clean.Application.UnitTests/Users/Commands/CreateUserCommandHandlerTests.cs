using AutoMapper;
using Moq;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Application.Features.User.Handlers.Commands;
using MyEshop_Clean.Application.Features.User.Requests.Commands;
using MyEshop_Clean.Application.Profiles;
using MyEshop_Clean.Application.Response;
using Shouldly;

namespace MyEshop_Clean.Application.UnitTests.Users.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly CreateUserDto _userDto;
        public CreateUserCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _userRepository = MockUserRepository.GetUserRepositoryMock();
            _mapper = mapperConfiguration.CreateMapper();
            _userDto = new CreateUserDto()
            {
                Id = 7, 
                Email = "CreateUserMock@gmail.com",
                Password = "Mock12345678",
                RegisterDate = DateTime.Now
            };
        }

        [Fact]
        public async Task UserAddTest()
        {
            var handler = new CreateUserCommandHandler(_mapper, _userRepository.Object);
            var result = await handler.Handle(new CreateUserCommand()
            {
                CreateUserDto = _userDto
            }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var users = await _userRepository.Object.GetAllAsync();
            users.Count.ShouldBe(4);
        }
    }
}
