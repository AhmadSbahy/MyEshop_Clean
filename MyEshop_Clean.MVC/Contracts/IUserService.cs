using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Contracts
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsers();
        Task<UserViewModel> GetUserDetail(int id);
        Task<Response<int>> CreateUser(CreateUserViewModel createUserViewModel);
        Task<Response<int>> UpdateUser(int id, UpdateUserViewModel updateUserViewModel);
        Task<Response<int>> DeleteUser(int id);

        Task<bool> IsExistUserByEmail(string email);
        Task<UserViewModel> GetUserForLogin(string email, string password);

    }
}
