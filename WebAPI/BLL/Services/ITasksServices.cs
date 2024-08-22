using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public interface ITasksServices
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks?> GetTasksByIdAsync(Guid id);
        Task AddTasksAsync(Tasks tasks);
        Task UpdateTasksAsync(Tasks tasks);
        Task DeleteTasksAsync(Guid id);
    }
}
