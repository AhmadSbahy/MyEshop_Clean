using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
	public interface ICategoryToProductRepository
	{
		Task<CategoryToProduct> GetAsync(int id);
		Task<IReadOnlyList<CategoryToProduct>> GetAllAsync();
		Task<bool> IsExist(int id);
		Task<CategoryToProduct> AddAsync(CategoryToProduct categoryToProduct);
		Task UpdateAsync(CategoryToProduct categoryToProduct);
		Task DeleteAsync(CategoryToProduct categoryToProduct);
		Task DeleteAsync(int id);
	}
}
