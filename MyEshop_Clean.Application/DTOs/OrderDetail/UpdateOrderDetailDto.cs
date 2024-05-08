using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Domain.Common;

namespace MyEshop_Clean.Application.DTOs.OrderDetail
{
    public class UpdateOrderDetailDto : BaseDto,IOrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
