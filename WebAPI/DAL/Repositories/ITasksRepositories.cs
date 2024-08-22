using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public interface ITasksRepositories
    {
        Task<IEnumerable<Tasks>> GetAllAsync();
        Task<Tasks?> GetByIdAsync(Guid id);
        Task AddAsync(Tasks tasks);
        Task UpdateAsync(Tasks tasks);
        Task DeleteAsync(Tasks tasks);
    }
}
