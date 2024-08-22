using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class TasksServices
    {
        private readonly ITasksRepositories _tasksRepositories;

        public TasksServices(ITasksRepositories tasksRepositories)
        {
            _tasksRepositories = tasksRepositories;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _tasksRepositories.GetAllAsync();
        }

        public async Task<Tasks?> GetTasksByIdAsync(Guid id)
        {
            return await _tasksRepositories.GetByIdAsync(id);
        }

        public async Task AddTasksAsync(Tasks tasks)
        {
            await _tasksRepositories.AddAsync(tasks);
        }

        public async Task UpdateTasksAsync(Tasks tasks)
        {
            await _tasksRepositories.UpdateAsync(tasks);
        }

        public async Task DeleteTasksAsync(Guid id)
        {
            var tasks = await _tasksRepositories.GetByIdAsync(id);
            if (tasks != null)
            {
                await _tasksRepositories.DeleteAsync(tasks);
            }
        }
    }
}
