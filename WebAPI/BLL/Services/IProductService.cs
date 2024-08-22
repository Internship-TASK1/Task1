using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
        Task<Category> GetCategoryByIdAsync(Guid id);
    }
}
