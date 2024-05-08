using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyEshop_Clean.Application.Contracts.Persistence;

namespace MyEshop_Clean.Application.DTOs.OrderDetail.Validators
{
    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public UpdateOrderDetailValidator(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            Include(new OrderDetailDtoValidator(_orderDetailRepository));
        }
    }
}
