using MyEshop_Clean.MVC.Base.Services;
using MyEshop_Clean.MVC.Models.Category;

namespace MyEshop_Clean.MVC.Models.Product
{
    public class DetailViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
