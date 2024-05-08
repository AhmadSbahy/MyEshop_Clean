using MyEshop_Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop_Clean.Domain
{
    public class Item : BaseDomainEntity
    {
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }


        public Product Product { get; set; }
    }
}
