using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Model;

namespace TaskManagementAPI.Controllers
{
    [Route("tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // POST /tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                AssignedToId = dto.AssignedToId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        // GET /tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.Comments)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // GET /tasks/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUser(int userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.AssignedToId == userId)
                .ToListAsync();

            return Ok(tasks);
        }
    }
}
