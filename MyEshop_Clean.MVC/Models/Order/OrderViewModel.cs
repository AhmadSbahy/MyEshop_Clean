using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.OrderDetail;
using MyEshop_Clean.MVC.Models.User;

namespace MyEshop_Clean.MVC.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public System.DateTime CreateDate { get; set; }

        public bool IsFinally { get; set; }

        public UserViewModel Users { get; set; }

        public System.Collections.Generic.ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
