using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.OrderDetail.Validators
{
    public class OrderDetailDtoValidator : AbstractValidator<IOrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailDtoValidator(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            RuleFor(p => p.ProductId)
                .GreaterThan(0).NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            RuleFor(p => p.OrderId)
                .GreaterThan(0).NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            RuleFor(p => p.Price)
                .NotNull().NotEmpty().WithMessage("مقدار وارد شده معتبر نمی باشد");

            
        }
    }
}
