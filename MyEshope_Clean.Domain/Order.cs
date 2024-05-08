using MyEshop_Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop_Clean.Domain
{
    public class Order : BaseDomainEntity
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }


        public User Users { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
