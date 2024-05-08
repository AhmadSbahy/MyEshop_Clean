using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.CategoryToProduct
{
    public class UpdateCategoryToProductDto:BaseDto,ICategoryToProductDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
}
