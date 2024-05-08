using MyEshop_Clean.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopContext _context;

        public CategoryRepository(EshopContext context) 
        {
            _context = context;
        }

        public async Task<Category> GetAsync(int id)
        {
            var category = await _context.Categories
                .Include(x=>x.CategoryToProducts.ToList())
                .ThenInclude(x=>x.Category)
                .SingleOrDefaultAsync(x=>x.Id == id);
            return category;
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            var categories = await _context.Categories
                .Include(x=>x.CategoryToProducts)
                .ThenInclude(x=>x.Product)
                .ToListAsync();
            return categories;
        }

        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _context.Categories.AnyAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            await DeleteAsync(category);
        }
    }
}
