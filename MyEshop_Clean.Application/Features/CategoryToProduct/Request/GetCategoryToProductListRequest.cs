using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyEshop_Clean.Application.DTOs.CategoryToProduct;

namespace MyEshop_Clean.Application.Features.CategoryToProduct.Request
{
	public class GetCategoryToProductListRequest : IRequest<List<CategoryToProductDto>>
	{
	}
}
