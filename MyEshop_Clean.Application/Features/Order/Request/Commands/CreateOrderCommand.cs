using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.Order;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Order.Request.Commands
{
    public class CreateOrderCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrderDto CreateOrderDto { get; set; }
    }
}
