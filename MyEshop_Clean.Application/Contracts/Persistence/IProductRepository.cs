using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.MVC.Base.Services;
using Item = MyEshop_Clean.Domain.Item;
using Product = MyEshop_Clean.Domain.Product;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<bool> IsExist(int id);
        Task<Product> AddAsync(Product product,Item item);
        Task UpdateAsync(Product product, MyEshop_Clean.Application.DTOs.Product.ItemDto itemDto);
        Task DeleteAsync(Product product);
        Task DeleteAsync(int id);
    }
}
