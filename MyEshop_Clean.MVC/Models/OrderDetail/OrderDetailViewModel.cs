using MyEshop_Clean.MVC.Base.Services;

namespace MyEshop_Clean.MVC.Models.OrderDetail
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public OrderDto Order { get; set; }

        public ProductDto Product { get; set; }


    }
}
