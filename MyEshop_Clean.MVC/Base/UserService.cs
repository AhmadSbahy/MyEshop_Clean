using AutoMapper;
using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Base
{
    public class UserService : BaseHttpService , IUserService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorageService;

        public UserService(IClient client, ILocalStorageService localStorage, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorage)
        {
            _mapper = mapper;
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            var users = await _client.UsersAllAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetUserDetail(int id)
        {
            var user = await _client.UsersGETAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<Response<int>> CreateUser(CreateUserViewModel createUserViewModel)
        {
            try
            {
                var response = new Response<int>();
                var createUser = _mapper.Map<CreateUserDto>(createUserViewModel);

                var apiResponse = await _client.UsersPOSTAsync(createUser);

                if ((bool)apiResponse.IsSuccess)
                {
                    response.IsSuccess = true;
                    response.Data = (int)apiResponse.Id;
                    response.Message = "User Created";
                }
                else
                {
                    foreach (var err in apiResponse.ErroresList)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<Response<int>> UpdateUser(int id,UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                var user = _mapper.Map<UpdateUserDto>(updateUserViewModel);
                await _client.UsersPUTAsync(id, user);
                return new Response<int>() { IsSuccess = true, Message = "User Updated" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<Response<int>> DeleteUser(int id)
        {
            try
            {
                await _client.UsersDELETEAsync(id);
                return new Response<int>() { IsSuccess = true, Message = "User Deleted" };
            }
            catch (ApiException e)
            {
                return ConvertApiException<int>(e);
            }
        }

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return (await _client.UsersAllAsync()).Any(u => u.Email == email);
        }

		public async Task<UserViewModel> GetUserForLogin(string email, string password)
		{
			var user = (await _client.UsersAllAsync()).FirstOrDefault(u => u.Email == email && u.Password == password);
			return _mapper.Map<UserViewModel>(user);
		}
	}
}
