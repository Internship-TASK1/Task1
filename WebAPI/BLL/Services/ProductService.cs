using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (product.Id != Guid.Empty) throw new ArgumentException("Id should not be provided when adding a new product.");

            try
            {
                if (product.CategoryId == null || product.CategoryId == Guid.Empty)
                {
                    throw new ArgumentException("CategoryId is required.");
                }

                var categoryExists = await _productRepository.CheckCategoryExistsAsync(product.CategoryId.Value);
                if (!categoryExists)
                {
                    throw new ArgumentException("Category does not exist.");
                }

                product.Id = Guid.NewGuid(); // Automatically set a new Id
                await _productRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (product.Id == Guid.Empty) throw new ArgumentException("Id is required when updating a product.");

            try
            {
                if (product.CategoryId == null || product.CategoryId == Guid.Empty)
                {
                    throw new ArgumentException("CategoryId is required.");
                }

                var categoryExists = await _productRepository.CheckCategoryExistsAsync(product.CategoryId.Value);
                if (!categoryExists)
                {
                    throw new ArgumentException("Category does not exist.");
                }

                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw;
            }
        }

        public async Task DeleteProductAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id is required when deleting a product.");

            try
            {
                await _productRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                // Log error if needed
                throw;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _productRepository.GetCategoryByIdAsync(id);
        }
    }
}
