using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.MVC.Base.Services;
using Item = MyEshop_Clean.Domain.Item;
using Product = MyEshop_Clean.Domain.Product;

namespace MyEshop_Clean.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EshopContext _context;

        public ProductRepository(EshopContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            var product = await _context.Products
                 .Include(x=>x.CategoryToProducts)
                 .ThenInclude(x=>x.Category)
                 .Include(x => x.Item)
                 .SingleOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(x=>x.Item).ToListAsync();
            return products;
        }

        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _context.Products.AnyAsync(x => x.Id == id);
            return isExist;
        }

        public async Task<Product> AddAsync(Product product, Item item)
        {
	        await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            product.ItemId = item.Id;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product, MyEshop_Clean.Application.DTOs.Product.ItemDto itemDto)
        {
	        product.Item = new Item()
	        {
		        Id = itemDto.Id,
		        Price = itemDto.Price,
		        QuantityInStock = itemDto.QuantityInStock
	        };
	        _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetAsync(id);
            await DeleteAsync(product);
        }
    }
}
