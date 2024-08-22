using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TasksRepository : ITasksRepositories
    {
        private readonly MyDbContext _context;

        public TasksRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync()
        {
            return await _context.Tasks
                                 .Include(t => t.Order)          // Tải kèm Order
                                 .Include(t => t.AssignedToUser) // Tải kèm User được giao
                                 .Include(t => t.CreatedByUser)  // Tải kèm User đã tạo
                                 .ToListAsync();
        }

        public async Task<Tasks?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks
                                 .Include(t => t.Order)          // Tải kèm Order
                                 .Include(t => t.AssignedToUser) // Tải kèm User được giao
                                 .Include(t => t.CreatedByUser)  // Tải kèm User đã tạo
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tasks tasks)
        {
            await _context.Tasks.AddAsync(tasks);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tasks tasks)
        {
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
        }
    }
}
