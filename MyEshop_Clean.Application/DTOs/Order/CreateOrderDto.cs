using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Order
{
    public class CreateOrderDto : BaseDto, IOrderDto
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }
    }
}
