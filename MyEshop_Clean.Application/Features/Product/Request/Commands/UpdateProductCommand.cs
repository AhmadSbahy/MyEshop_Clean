using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.Product;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Product.Request.Commands
{
    public class UpdateProductCommand : IRequest<BaseCommandResponse>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
