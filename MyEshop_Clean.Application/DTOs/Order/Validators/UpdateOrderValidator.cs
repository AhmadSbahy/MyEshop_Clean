using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Order.Validators
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public UpdateOrderValidator(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            Include(new OrderDtoValidator(_orderRepository,_userRepository));
            RuleFor(p => p.Id)
	            .MustAsync(async (id, token) =>
	            {
		            bool order = await _orderRepository.IsExist(id);
		            return order;
	            }).WithMessage("{PropertyName} پیدا نشد");
		}
    }
}
