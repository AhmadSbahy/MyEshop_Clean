using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.OrderDetail.Validators;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.OrderDetail.Handlers.Commands;

public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, BaseCommandResponse>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IMapper _mapper;

    public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateOrderDetailValidator(_orderDetailRepository);
        var validate = await validator.ValidateAsync(request.UpdateOrderDetailDto);
        if (validate.IsValid)
        {
            var orderDetail = _mapper.Map<Domain.OrderDetail>(request.UpdateOrderDetailDto);
            await _orderDetailRepository.UpdateAsync(orderDetail);

            response.Id = orderDetail.Id;
            response.IsSuccess = true;
            response.Message = "جزییات با موفقیت ویرایش شد";
        }
        else
        {
            response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
            response.IsSuccess = false;
            response.Message = "ویرایش جزییات با شکست مواجه شد";
        }

        return response;
    }
}