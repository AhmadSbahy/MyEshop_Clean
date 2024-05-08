using MyEshop_Clean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;
using MyEshop_Clean.Application.DTOs.Order;

namespace MyEshop_Clean.Application.DTOs.User
{
    public class UserDto : BaseDto,IUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; } = false;


        public List<OrderDto> Orders { get; set; }
    }
}
