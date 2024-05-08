using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.DTOs.Order.Validators;
using MyEshop_Clean.Application.DTOs.Product.Validators;
using MyEshop_Clean.Application.Features.Order.Request.Commands;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Order.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrderDtoValidator(_orderRepository,_userRepository);
            var validate = await validator.ValidateAsync(request.CreateOrderDto);
            if (validate.IsValid)
            {
                var order = _mapper.Map<Domain.Order>(request.CreateOrderDto);
                order = await _orderRepository.AddAsync(order);

                response.Id = order.Id;
                response.IsSuccess = true;
                response.Message = "فاکتور با موفقیت ساخته شد";
            }
            else
            {
                response.ErroresList = validate.Errors.Select(e => e.ErrorMessage).ToList();
                response.IsSuccess = false;
                response.Message = "ایجاد فاکتور با شکست مواجه شد";
            }
            return response;
        }
    }
}
