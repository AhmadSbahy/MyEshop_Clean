using MyEshop_Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop_Clean.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
