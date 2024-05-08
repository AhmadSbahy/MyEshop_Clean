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
    public class UserRepository : IUserRepository
    {
        private readonly EshopContext _context;

        public UserRepository(EshopContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _context.Users
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderDetails)
                .SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var users = await _context.Users.Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ToListAsync();
            return users;
        }

        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _context.Users.AnyAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            user.RegisterDate = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetAsync(id);
            await DeleteAsync(user);
        }
    }
}
