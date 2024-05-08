using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.Product.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            Include(new ProductDtoValidator(_productRepository));

            


		}
	}
}
