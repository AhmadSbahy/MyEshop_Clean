using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.DTOs.OrderDetail.Validators;
using MyEshop_Clean.Application.DTOs.Product.Validators;
using MyEshop_Clean.Application.Features.OrderDetail.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.OrderDetail.Handlers.Commands
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, BaseCommandResponse>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderDetailCommand request,
            CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrderDetailDtoValidator(_orderDetailRepository);
            var validate = await validator.ValidateAsync(request.CreateOrderDetailDto);
            if (validate.IsValid)
            {
                var orderDetail = _mapper.Map<Domain.OrderDetail>(request.CreateOrderDetailDto);
                orderDetail = await _orderDetailRepository.AddAsync(orderDetail);

                response.Id = orderDetail.Id;
                response.IsSuccess = true;
                response.Message = "جزییات محصول با موفقیت ساخته شد";
            }
            else
            {
                response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
                response.IsSuccess = false;
                response.Message = "ایجاد جزییات محصول با شکست مواجه شد";
            }

            return response;
        }
    }
}
