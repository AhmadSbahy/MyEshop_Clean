using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Order.Validators;
using MyEshop_Clean.Application.Features.Order.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Order.Handlers.Commands;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, BaseCommandResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<BaseCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateOrderValidator(_orderRepository,_userRepository);
        var validate = await validator.ValidateAsync(request.UpdateOrderDto);
        if (validate.IsValid)
        {
            var order = _mapper.Map<Domain.Order>(request.UpdateOrderDto);
            await _orderRepository.UpdateAsync(order);

            response.Id = order.Id;
            response.IsSuccess = true;
            response.Message = "جزییات فاکتور محصول با موفقیت ویرایش شد";
        }
        else
        {
            response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
            response.IsSuccess = false;
            response.Message = "ویرایش فاکتور جزییات محصول با شکست مواجه شد";
        }

        return response;
    }
}