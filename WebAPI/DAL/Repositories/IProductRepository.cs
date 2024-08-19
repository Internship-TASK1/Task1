using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task<bool> CheckCategoryExistsAsync(Guid categoryId);
    Task<Category> GetCategoryByIdAsync(Guid id);
}
