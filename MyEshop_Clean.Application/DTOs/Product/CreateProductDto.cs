using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Product
{
    public class CreateProductDto :BaseDto ,IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public List<CategoryDto>? Categories { get; set; }
    }
}
