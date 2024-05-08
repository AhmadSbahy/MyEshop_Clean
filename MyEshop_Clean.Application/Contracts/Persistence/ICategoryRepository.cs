using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(int id);
        Task<IReadOnlyList<Category>> GetAllAsync();
        Task<bool> IsExist(int id);
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task DeleteAsync(int id);
    }
}
