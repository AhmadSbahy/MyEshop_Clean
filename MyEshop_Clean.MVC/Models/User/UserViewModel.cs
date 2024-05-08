using MyEshop_Clean.MVC.Base.Services;

namespace MyEshop_Clean.MVC.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<OrderDto> Orders { get; set; }

    }
}