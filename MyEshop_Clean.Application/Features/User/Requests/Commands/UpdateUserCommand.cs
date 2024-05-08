using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.User;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.User.Requests.Commands
{
    public class UpdateUserCommand : IRequest<BaseCommandResponse>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
