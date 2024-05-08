using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.Product;

namespace MyEshop_Clean.Application.DTOs.CategoryToProduct
{
    public class CategoryToProductDto:BaseDto, ICategoryToProductDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        //Navigation Property
        public CategoryDto Category { get; set; }
        public ProductDto? Product { get; set; }
    }
}
