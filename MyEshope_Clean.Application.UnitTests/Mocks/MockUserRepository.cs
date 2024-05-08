using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.UnitTests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepositoryMock()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Email = "mockEmail1@gmail.com",
                    IsAdmin = false,
                    Orders = new List<Order>(),
                    Password = "mock1234",
                    RegisterDate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    Email = "mockEmail2@gmail.com",
                    IsAdmin = true,
                    Orders = new List<Order>(),
                    Password = "mock1234",
                    RegisterDate = DateTime.Now
                },
                new User()
                {
                    Id = 3,
                    Email = "mockEmail3@gmail.com",
                    IsAdmin = true,
                    Orders = new List<Order>(),
                    Password = "mock1234",
                    RegisterDate = DateTime.Now
                }
            };
            var userMock = new Mock<IUserRepository>();

            userMock.Setup(u => u.GetAllAsync())
                .ReturnsAsync(users);

            userMock.Setup(u => u.AddAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) =>
                {
                    users.Add(user);
                    return user;
                });

            //userMock.Setup(u => u.DeleteAsync(It.IsAny<User>()))
            //    .Returns((User user) =>
            //    {
            //        users.Remove(user);
            //        return user;
            //    });

            //userMock.Setup(u => u.UpdateAsync(It.IsAny<User>()))
            //    .Returns((User updateUser) =>
            //    {
            //        var user = users.FirstOrDefault(p => p.Id == updateUser.Id);
            //        user = updateUser;
            //    });

            return userMock;
        }
    }
}
