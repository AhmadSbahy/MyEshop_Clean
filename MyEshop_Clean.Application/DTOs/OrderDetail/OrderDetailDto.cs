using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.DTOs.Product;

namespace MyEshop_Clean.Application.DTOs.OrderDetail
{
    public class OrderDetailDto:BaseDto,IOrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
