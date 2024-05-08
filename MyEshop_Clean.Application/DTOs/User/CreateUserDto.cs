using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.User
{
    public class CreateUserDto : BaseDto,IUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
