using Microsoft.AspNetCore.Mvc;
using MyEshop_Clean.MVC.Contracts;

namespace MyEshop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public ProductGroupsComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml", await _categoryService.GetCategoriesForShow());
        }
    }
}
