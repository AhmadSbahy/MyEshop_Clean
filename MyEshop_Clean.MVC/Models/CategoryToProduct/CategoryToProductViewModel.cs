using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Category;
using MyEshop_Clean.MVC.Models.Product;

namespace MyEshop_Clean.MVC.Models.CategoryToProduct
{
    public class CategoryToProductViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public CategoryViewModel Category { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
