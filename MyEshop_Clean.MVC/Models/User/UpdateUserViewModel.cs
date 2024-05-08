namespace MyEshop_Clean.MVC.Models.User
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

    }
}
