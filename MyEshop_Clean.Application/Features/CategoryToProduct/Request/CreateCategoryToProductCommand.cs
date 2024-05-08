using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;
using MyEshop_Clean.Application.Response;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Request
{
	public class CreateCategoryToProductCommand : IRequest<BaseCommandResponse>
	{
		public CreateCategoryToProductDto CreateCategoryToProductDto { get; set; }
	}
}
