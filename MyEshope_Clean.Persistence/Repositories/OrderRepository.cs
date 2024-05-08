using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EshopContext _context;

        public OrderRepository(EshopContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task DeleteAsync(int id)
        {
            var order = await GetAsync(id);
            await DeleteAsync(order);
        }
        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Order>> GetAllAsync()
        {
            var orders = await _context.Orders
	            .Include(x=>x.OrderDetails)
	            .ThenInclude(x=>x.Product)
	            .ToListAsync();
            return orders;
        }

        public async Task<Order> GetAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _context.Orders.AnyAsync(o => o.Id == id);
            return isExist;
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
