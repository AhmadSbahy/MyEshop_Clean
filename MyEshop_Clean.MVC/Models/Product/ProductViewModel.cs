using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.CategoryToProduct;

namespace MyEshop_Clean.MVC.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ItemId { get; set; }

        public System.Collections.Generic.ICollection<CategoryToProductViewModel> CategoryToProducts { get; set; }

        public Item? Item { get; set; }

        public System.Collections.Generic.ICollection<OrderDetailDto> OrderDetails { get; set; }

    }
}
