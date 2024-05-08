using MyEshop_Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop_Clean.Domain
{
    public class User : BaseDomainEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }


        public List<Order>? Orders { get; set; }
    }
}
