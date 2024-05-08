using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.OrderDetail.Validators
{
    public class CreateOrderDetailDtoValidator : AbstractValidator<CreateOrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public CreateOrderDetailDtoValidator(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            Include(new OrderDetailDtoValidator(_orderDetailRepository));
        }
    }
}
