namespace MyEshop_Clean.MVC.Models.Order
{
    public class UpdateOrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool IsFinally { get; set; }
    }
}
