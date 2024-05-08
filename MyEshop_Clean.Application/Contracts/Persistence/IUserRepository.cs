using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEshop_Clean.Domain;

namespace MyEshop_Clean.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<bool> IsExist(int id);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task DeleteAsync(int id);
    }
}
