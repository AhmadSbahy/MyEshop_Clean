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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EshopContext _context;

        public OrderDetailRepository(EshopContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<OrderDetail>> GetAllAsync()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();
            return orderDetails;
        }
        public async Task DeleteAsync(int id)
        {
            var orderDetail = await GetAsync(id);
            await DeleteAsync(orderDetail);
        }

        public async Task<OrderDetail> GetAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            return orderDetail;
        }

        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _context.OrderDetails.AnyAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
}
