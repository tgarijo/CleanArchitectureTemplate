using CleanArchitectureTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces
{
    public  interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task AddSync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

    }
}
