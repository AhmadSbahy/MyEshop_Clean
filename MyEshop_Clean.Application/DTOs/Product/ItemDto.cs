using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Application.DTOs.Common;

namespace MyEshop_Clean.Application.DTOs.Product
{
	public class ItemDto : BaseDto
	{
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
	}
}
