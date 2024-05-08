using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEshop_Clean.Domain.Common;

namespace MyEshop_Clean.Domain
{
    public class CategoryToProduct : BaseDomainEntity
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
