using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
	        _userService = userService;
        }

        public IEnumerable<UserViewModel> Users { get; set; }
        public async Task OnGet()
        {
	        Users = await _userService.GetUsers();
        }
    }
}
