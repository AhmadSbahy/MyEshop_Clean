using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetAsync(int id);
        Task<IReadOnlyList<OrderDetail>> GetAllAsync();
        Task<bool> IsExist(int id);
        Task<OrderDetail> AddAsync(OrderDetail orderDetail);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(OrderDetail orderDetail); 
        Task DeleteAsync(int id);
    }
}
