using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Product
{
    public class UpdateProductDto : BaseDto,IProductDto
    {
	    public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile? Picture { get; set; }
        public List<CategoryDto>? Categories { get; set; }
        public ItemDto ItemDto { get; set; }
    }
}
