using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Category;

namespace MyEshop_Clean.MVC.Models.Product
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int QuantityInStock { get; set; }

        public IFormFile? Picture { get; set; }

        public System.Collections.Generic.ICollection<CategoryViewModel>? Categories { get; set; }
    }
}
