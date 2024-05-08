using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Order
{
    public class UpdateOrderDto : BaseDto,IOrderDto
    {
        public int UserId { get; set; }
        public bool IsFinally { get; set; }
    }
}
