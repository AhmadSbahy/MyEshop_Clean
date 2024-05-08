namespace MyEshop_Clean.MVC.Models.OrderDetail
{
    public class CreateOrderDetailViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }
    }
}
