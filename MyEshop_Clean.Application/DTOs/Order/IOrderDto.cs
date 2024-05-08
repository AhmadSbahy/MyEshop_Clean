namespace MyEshop_Clean.Application.DTOs.Order
{
    public interface IOrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsFinally { get; set; }
    }
}
