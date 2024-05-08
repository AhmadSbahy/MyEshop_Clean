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
	public class CategoryToProductRepository : ICategoryToProductRepository
	{
		private readonly EshopContext _context;

		public CategoryToProductRepository(EshopContext context)
		{
			_context = context;
		}

		public async Task<CategoryToProduct> GetAsync(int id)
		{
			var category = await _context.CategoryToProducts.FindAsync(id);
			return category;
		}

		public async Task<IReadOnlyList<CategoryToProduct>> GetAllAsync()
		{
			var categoryToProduct = await _context.CategoryToProducts.ToListAsync();
			return categoryToProduct;
		}

		public async Task<bool> IsExist(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<CategoryToProduct> AddAsync(CategoryToProduct categoryToProduct)
		{
			await _context.CategoryToProducts.AddAsync(categoryToProduct);
			await _context.SaveChangesAsync();
			return categoryToProduct;
		}

		public async Task UpdateAsync(CategoryToProduct categoryToProduct)
		{ 
			_context.CategoryToProducts.Update(categoryToProduct);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(CategoryToProduct categoryToProduct)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(int id)
		{
			var category = await GetAsync(id);
			_context.CategoryToProducts.Remove(category);
			await _context.SaveChangesAsync();
		}
	}
}
