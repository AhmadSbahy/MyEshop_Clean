using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyEshop_Clean.Domain.Common;

namespace MyEshop_Clean.Domain
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}
