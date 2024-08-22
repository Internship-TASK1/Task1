using DAL.Entities;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _tasksService;

        public TasksController(ITasksServices tasksService)
        {
            _tasksService = tasksService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(Guid id)
        {
            var tasks = await _tasksService.GetTasksByIdAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<Tasks>> CreateTasks(Tasks tasks)
        {
            await _tasksService.AddTasksAsync(tasks);
            return CreatedAtAction(nameof(GetTasks), new { id = tasks.Id }, tasks);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTasks(Guid id, Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return BadRequest();
            }

            var existingTasks = await _tasksService.GetTasksByIdAsync(id);
            if (existingTasks == null)
            {
                return NotFound();
            }

            await _tasksService.UpdateTasksAsync(tasks);
            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(Guid id)
        {
            var existingTasks = await _tasksService.GetTasksByIdAsync(id);
            if (existingTasks == null)
            {
                return NotFound();
            }

            await _tasksService.DeleteTasksAsync(id);
            return NoContent();
        }
    }
}
