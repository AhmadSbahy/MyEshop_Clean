using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Pages.Admin.ManageUsers
{
    public class CreateModel : PageModel
    {
	    private readonly IUserService _userService;

	    public CreateModel(IUserService userService)
	    {
		    _userService = userService;
	    }
	    public void OnGet()
        {
        }

        [BindProperty]
        public CreateUserViewModel User { get; set; }

        public async Task<IActionResult> OnPost()
        {
	        await _userService.CreateUser(User);
	        return RedirectToPage("Index");
        }
    }
}
