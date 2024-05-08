using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.DTOs.Product
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }

        public ICollection<CategoryToProductDto> CategoryToProducts { get; set; }
        public Item? Item { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
