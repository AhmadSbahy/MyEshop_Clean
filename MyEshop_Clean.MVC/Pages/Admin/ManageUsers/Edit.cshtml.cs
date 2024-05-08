using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshop_Clean.MVC.Contracts;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Pages.Admin.ManageUsers
{
    public class EditModel : PageModel
    {
	    private readonly IUserService _userService;
	    private readonly IMapper _mapper;

	    public EditModel(IUserService userService, IMapper mapper)
	    {
		    _userService = userService;
		    _mapper = mapper;
	    }

	    [BindProperty]
		public UpdateUserViewModel User { get; set; }
		public async Task OnGet(int id)
		{
			User = _mapper.Map<UpdateUserViewModel>(await _userService.GetUserDetail(id));
		}

		public async Task<IActionResult> OnPost()
		{
			await _userService.UpdateUser(User.Id, User);
			return RedirectToPage("Index");
		}
    }
}
