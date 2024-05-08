using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MyEshop_Clean.Application.Features.User.Requests.Commands
{
    public class DeleteUserCommand :IRequest
    {
        public int Id { get; set; } 
    }
}
