using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _context.Categories
                    .Select(c => new Category
                    {
                        Id = c.Id,
                        Name = c.Name ?? string.Empty,
                        Description = c.Description ?? string.Empty,
                        CreatedBy = c.CreatedBy ?? string.Empty,
                        LastUpdatedBy = c.LastUpdatedBy ?? string.Empty,
                        DeletedBy = c.DeletedBy ?? string.Empty,
                        CreatedTime = c.CreatedTime,
                        LastUpdatedTime = c.LastUpdatedTime,
                        DeletedTime = c.DeletedTime
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving categories: {ex.Message}");
                throw;
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            try
            {
                return await _context.Categories.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"An error occurred while retrieving the category: {ex.Message}");
                throw;
            }
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"An error occurred while adding the category: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"An error occurred while updating the category: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine($"An error occurred while deleting the category: {ex.Message}");
                throw;
            }
        }

    }
}
