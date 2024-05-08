using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Category
{
    public class CreateCategoryDto : BaseDto,ICategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
