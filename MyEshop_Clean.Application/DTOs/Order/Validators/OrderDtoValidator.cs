using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Order.Validators
{
    public class OrderDtoValidator : AbstractValidator<IOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderDtoValidator(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;

            RuleFor(p => p.UserId)
                .NotNull().NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    bool user = await _userRepository.IsExist(id);
                    return user;
                }).WithMessage("{PropertyName} پیدا نشد");


           
        }
    }
}
