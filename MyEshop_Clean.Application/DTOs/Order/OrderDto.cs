using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.User;

namespace MyEshop_Clean.Application.DTOs.Order
{
    public class OrderDto :BaseDto,IOrderDto
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }


        public UserDto Users { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
