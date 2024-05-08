using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.User;

namespace MyEshop_Clean.Application.Features.User.Requests.Queries
{
    public class GetUserDetailRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
