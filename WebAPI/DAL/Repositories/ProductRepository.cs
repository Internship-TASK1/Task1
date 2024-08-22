using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckCategoryExistsAsync(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }
        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            var existingCategory = await _context.Categories.FindAsync(product.CategoryId);
            if (existingCategory == null)
            {
                throw new ArgumentException("Category not found.");
            }

            product.Category = existingCategory; // Liên kết với category đã tồn tại
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
