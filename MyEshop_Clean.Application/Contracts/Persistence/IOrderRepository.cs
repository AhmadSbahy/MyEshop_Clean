using MyEshop_Clean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int id);
        Task<IReadOnlyList<Order>> GetAllAsync();
        Task<bool> IsExist(int id);
        Task<Order> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task DeleteAsync(int id);
    }
}
