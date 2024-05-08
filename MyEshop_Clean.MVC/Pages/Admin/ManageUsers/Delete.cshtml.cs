using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Pages.Admin.ManageUsers
{
    public class DeleteModel : PageModel
    {
	    private readonly IUserService _userService;

	    public DeleteModel(IUserService userService)
	    {
		    _userService = userService;
	    }
		[BindProperty]
	    public UserViewModel User { get; set; }
	    public async Task OnGet(int id)
	    {
		    User = await _userService.GetUserDetail(id);
	    }

	    public async Task<IActionResult> OnPost()
	    {
		    await _userService.DeleteUser(User.Id);
			return RedirectToPage("Index");
	    }
    }
}
