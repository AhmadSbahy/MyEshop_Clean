using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.OrderDetail;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.OrderDetail.Request.Commands
{
    public class CreateOrderDetailCommand : IRequest<BaseCommandResponse>
    {
        public CreateOrderDetailDto CreateOrderDetailDto { get; set; }
    }
}
