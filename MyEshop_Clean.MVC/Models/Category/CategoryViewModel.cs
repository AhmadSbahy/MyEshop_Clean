using MyEshop_Clean.MVC.Base.Services;

namespace MyEshop_Clean.MVC.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.Collections.Generic.ICollection<CategoryToProductDto> CategoryToProducts { get; set; }
    }
}
