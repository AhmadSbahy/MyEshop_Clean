using MyEshop_Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop_Clean.Domain
{
    public class OrderDetail : BaseDomainEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
