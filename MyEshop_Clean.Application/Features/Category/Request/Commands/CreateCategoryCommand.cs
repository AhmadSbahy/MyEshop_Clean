using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.Category;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.Category.Request.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
