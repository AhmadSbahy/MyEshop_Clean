using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Request
{
	public class DeleteCategoryToProductCommand : IRequest
	{
		public int Id { get; set; }
	}
}
