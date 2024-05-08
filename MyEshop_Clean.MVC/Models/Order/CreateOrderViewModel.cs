namespace MyEshop_Clean.MVC.Models.Order
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public System.DateTime CreateDate { get; set; }

        public bool IsFinally { get; set; }
    }
}
